using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using static UAPI.Type;

namespace UAPI.Diagnostics
{
    /// <summary>
    /// UAPI SDK 轻量诊断入口。适合 CLI / WinForms / 普通程序集宿主使用，不依赖 Reporter / AntdUI。
    /// </summary>
    public static partial class UapiGlobalExceptionHook
    {
        private static int _installed;
        private static int _handling;

        /// <summary>
        /// 安装全局异常 Hook。建议在 CLI Main 或 WinForms Program.Main 开头调用一次。
        /// </summary>
        public static void Install(string reportDirectory = null, bool writeConsole = true)
        {
            if (Interlocked.Exchange(ref _installed, 1) == 1)
                return;

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                    Handle(ex, reportDirectory, writeConsole);
            };

            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                Handle(e.Exception, reportDirectory, writeConsole);
                e.SetObserved();
            };
        }

        /// <summary>
        /// 立即生成一次 UAPI 诊断报告。
        /// </summary>
        public static string Handle(Exception exception, string reportDirectory = null, bool writeConsole = true)
        {
            if (exception == null)
                return null;

            if (Interlocked.Exchange(ref _handling, 1) == 1)
                return null;

            try
            {
                var path = UapiDiagnosticReport.Save(exception, reportDirectory);

                if (!writeConsole) return path;
                Console.Error.WriteLine("[UAPI Error] " + exception.GetType().FullName);
                Console.Error.WriteLine(exception.Message);
                Console.Error.WriteLine("Report: " + path);

                return path;
            }
            catch (Exception reporterException)
            {
                if (writeConsole)
                    Console.Error.WriteLine("[UAPI Reporter Error] " + reporterException);
                return null;
            }
            finally
            {
                Interlocked.Exchange(ref _handling, 0);
            }
        }
    }

    /// <summary>
    /// UAPI 诊断报告构建器。报告内容参考 Rox Reporter，但不绑定任何 UI。
    /// </summary>
    public static class UapiDiagnosticReport
    {
        public static string Save(Exception exception, string directory = null)
        {
            var reportDirectory = string.IsNullOrWhiteSpace(directory)
                ? AppDomain.CurrentDomain.BaseDirectory
                : directory;

            Directory.CreateDirectory(reportDirectory);

            var fileName = "uapi_crash_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss-fff") + ".log";
            var path = Path.Combine(reportDirectory, fileName);
            UapiExceptionData.Add(exception, "UAPI.DiagnosticReportPath", path);
            File.WriteAllText(path, Build(exception), Encoding.UTF8);
            return path;
        }

        public static string Build(Exception exception)
        {
            var sb = new StringBuilder(16 * 1024);

            sb.AppendLine("[UAPI Diagnostic Report]");
            AppendException(sb, exception);
            AppendExceptionData(sb, exception);
            AppendSystemInfo(sb);
            AppendAppInfo(sb);
            AppendLoadedAssemblies(sb);

            return sb.ToString();
        }

        private static void AppendException(StringBuilder sb, Exception exception)
        {
            sb.AppendLine("-------------Exception--------------------");
            sb.AppendLine("Exception Type: " + Safe(() => exception == null ? "<null>" : exception.GetType().FullName));
            sb.AppendLine("Exception Message: " + Safe(() => exception == null ? "<null>" : exception.Message));
            sb.AppendLine("Exception StackTrace:");
            sb.AppendLine(exception?.StackTrace ?? "<null>");
            sb.AppendLine("Now Time: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            var current = exception?.InnerException;
            var index = 1;
            while (current != null)
            {
                sb.AppendLine("-------------InnerException #" + index + "-------------");
                sb.AppendLine("Exception Type: " + current.GetType().FullName);
                sb.AppendLine("Exception Message: " + current.Message);
                sb.AppendLine("Exception StackTrace:");
                sb.AppendLine(current.StackTrace ?? "<null>");
                current = current.InnerException;
                index++;
            }

            if (!(exception is AggregateException aggregate))
                return;

            var i = 1;
            foreach (var inner in aggregate.Flatten().InnerExceptions)
            {
                sb.AppendLine("-------------AggregateException #" + i + "-------------");
                sb.AppendLine("Exception Type: " + inner.GetType().FullName);
                sb.AppendLine("Exception Message: " + inner.Message);
                sb.AppendLine("Exception StackTrace:");
                sb.AppendLine(inner.StackTrace ?? "<null>");
                i++;
            }
        }

        private static void AppendExceptionData(StringBuilder sb, Exception exception)
        {
            if (exception?.Data == null || exception.Data.Count == 0)
                return;

            sb.AppendLine("-------------Exception Context-------------");
            foreach (DictionaryEntry item in exception.Data)
                sb.AppendLine(Convert.ToString(item.Key) + ": " + Convert.ToString(item.Value));
        }

        private static void AppendSystemInfo(StringBuilder sb)
        {
            sb.AppendLine("-------------SystemInfo-------------------");
            sb.AppendLine("SystemName: " + GetWindowsProductName());
            sb.AppendLine("SystemBuild: " + Environment.OSVersion.Version);
            sb.AppendLine("SystemArchitecture: " + (Environment.Is64BitOperatingSystem ? "64 位" : "32 位"));
            sb.AppendLine("SystemLanguage: " + CultureInfo.InstalledUICulture.Name);
            sb.AppendLine("MonitorResolution: " + GetPrimaryScreenResolution());
            sb.AppendLine("Processor: " + GetProcessorName());
            sb.AppendLine("MachineName: " + Environment.MachineName);
            sb.AppendLine("UserName: " + Environment.UserName);
            sb.AppendLine("ProcessArchitecture: " + (Environment.Is64BitProcess ? "64 位" : "32 位"));
            sb.AppendLine("RuntimeVersion: " + Environment.Version);
            sb.AppendLine("CLR: " + Safe(() => RuntimeEnvironmentVersion()));
        }

        private static void AppendAppInfo(StringBuilder sb)
        {
            sb.AppendLine("-------------AppInfo----------------------");

            var entry = Assembly.GetEntryAssembly();
            var executing = Assembly.GetExecutingAssembly();
            var asm = entry ?? executing;

            sb.AppendLine("AppExecutable: " + GetExecutablePath());
            sb.AppendLine("EntryAssembly: " + (entry == null ? "<null>" : entry.FullName));
            sb.AppendLine("ExecutingAssembly: " + executing.FullName);
            sb.AppendLine("AssemblyVersion: " + asm.GetName().Version);

            try
            {
                var location = asm.Location;
                if (!string.IsNullOrWhiteSpace(location))
                {
                    var fvi = FileVersionInfo.GetVersionInfo(location);
                    sb.AppendLine("FileVersion: " + (fvi.FileVersion ?? "<null>"));
                    sb.AppendLine("ProductVersion: " + (fvi.ProductVersion ?? "<null>"));
                }
            }
            catch
            {
                sb.AppendLine("FileVersion: <failed>");
                sb.AppendLine("ProductVersion: <failed>");
            }

            var attr = asm.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            sb.AppendLine("InformationalVersion: " + (attr == null ? "<null>" : attr.InformationalVersion));
            sb.AppendLine("BaseDirectory: " + AppDomain.CurrentDomain.BaseDirectory);
            sb.AppendLine("CurrentDirectory: " + Environment.CurrentDirectory);
            sb.AppendLine("CommandLine: " + Environment.CommandLine);
        }

        private static void AppendLoadedAssemblies(StringBuilder sb)
        {
            sb.AppendLine("-------------Loaded Assemblies------------");
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    var name = assembly.GetName();
                    sb.AppendLine("Assembly: " + name.Name + ", Version: " + name.Version);
                }
                catch
                {
                    // ignored
                }
            }
        }

        private static string GetWindowsProductName()
        {
            try
            {
                using var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
                var productName = key == null ? null : Convert.ToString(key.GetValue("ProductName"));
                var displayVersion = key == null ? null : Convert.ToString(key.GetValue("DisplayVersion"));
                var currentBuild = key == null ? null : Convert.ToString(key.GetValue("CurrentBuildNumber"));

                var value = (productName ?? Environment.OSVersion.ToString()).Trim();
                if (!string.IsNullOrWhiteSpace(displayVersion))
                    value += " " + displayVersion;
                if (!string.IsNullOrWhiteSpace(currentBuild))
                    value += " " + currentBuild;
                return value;
            }
            catch
            {
                return Environment.OSVersion.ToString();
            }
        }

        private static string GetProcessorName()
        {
            try
            {
                using var key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");
                var value = key == null ? null : Convert.ToString(key.GetValue("ProcessorNameString"));
                return string.IsNullOrWhiteSpace(value) ? "<unknown>" : value.Trim();
            }
            catch
            {
                return "<unknown>";
            }
        }

        private static string GetPrimaryScreenResolution()
        {
            try
            {
                var screenType = System.Type.GetType("System.Windows.Forms.Screen, System.Windows.Forms");

                var primaryScreen = screenType?.GetProperty("PrimaryScreen").GetValue(null, null);
                if (primaryScreen == null)
                    return "<unavailable>";

                var bounds = primaryScreen.GetType().GetProperty("Bounds").GetValue(primaryScreen, null);
                var width = bounds.GetType().GetProperty("Width").GetValue(bounds, null);
                var height = bounds.GetType().GetProperty("Height").GetValue(bounds, null);
                return width + "x" + height;
            }
            catch
            {
                return "<unavailable>";
            }
        }

        private static string GetExecutablePath()
        {
            try
            {
                return Process.GetCurrentProcess().MainModule.FileName;
            }
            catch
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        private static string RuntimeEnvironmentVersion()
        {
            try
            {
                return System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion();
            }
            catch
            {
                return "<unknown>";
            }
        }

        private static string Safe(Func<string> getter)
        {
            try
            {
                return getter();
            }
            catch (Exception ex)
            {
                return "<failed: " + ex.Message + ">";
            }
        }
    }

    internal sealed class UapiRequestTrace
    {
        private static readonly AsyncLocal<UapiRequestTrace> CurrentTrace = new AsyncLocal<UapiRequestTrace>();
        private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
        private readonly StringBuilder _events = new StringBuilder(4096);

        private UapiRequestTrace()
        {
            TraceId = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "-" +
                      Guid.NewGuid().ToString("N").Substring(0, 8).ToUpperInvariant();
            StartTime = DateTime.Now;
        }

        public string TraceId { get; private set; }
        public DateTime StartTime { get; private set; }
        public string RequestUrl { get; private set; }
        public string BackupUrl { get; private set; }
        public string RequestType { get; private set; }
        public string ContentType { get; private set; }
        public string PostContentType { get; private set; }
        public int? PostContentLength { get; private set; }
        public string TokenSha256 { get; private set; }
        public string ResultType { get; private set; }
        public string RawBodyType { get; private set; }
        public int? StatusCode { get; private set; }
        public string ReasonPhrase { get; private set; }
        public string ResponseBodyType { get; private set; }
        public int? ResponseBodyLength { get; private set; }
        public string ResponseBodyPreview { get; private set; }
        public Response.Headers Headers { get; private set; }
        public Exception OriginalException { get; private set; }

        public static UapiRequestTrace Current => CurrentTrace.Value;

        public static UapiRequestTrace Start(string requestUrl, string requestType, object postContent,
            string contentType,
            string authenticationToken, System.Type resultType, System.Type rawBodyType)
        {
            var trace = new UapiRequestTrace
            {
                RequestUrl = requestUrl,
                RequestType = requestType,
                ContentType = contentType,
                ResultType = resultType == null ? null : resultType.FullName,
                RawBodyType = rawBodyType == null ? "<json>" : rawBodyType.FullName
            };

            trace.SetPostContent(postContent);
            trace.SetToken(authenticationToken);
            trace.Mark("Trace created");
            CurrentTrace.Value = trace;
            return trace;
        }

        public static void Clear()
        {
            CurrentTrace.Value = null;
        }

        public void Mark(string message)
        {
            try
            {
                _events.AppendLine("[+" + _stopwatch.ElapsedMilliseconds + "ms] " + message);
            }
            catch
            {
                // ignored
            }
        }

        public void CaptureException(Exception exception, int statusCode, string stage)
        {
            if (exception != null)
                OriginalException = exception;
            StatusCode = statusCode;
            Mark(stage + ": " +
                 (exception == null ? "<null>" : exception.GetType().FullName + " - " + exception.Message));
        }

        public void SetResponse(HttpResponseMessage response, Response.Headers headers, object body)
        {
            Headers = headers;
            if (response != null)
            {
                StatusCode = (int)response.StatusCode;
                ReasonPhrase = response.ReasonPhrase;
            }

            ResponseBodyType = body == null ? "<null>" : body.GetType().FullName;
            switch (body)
            {
                case string s:
                    ResponseBodyLength = s.Length;
                    ResponseBodyPreview = Limit(s, 4096);
                    break;
                case byte[] bytes:
                    ResponseBodyLength = bytes.Length;
                    ResponseBodyPreview = "<byte[] length=" + bytes.Length + ">";
                    break;
                default:
                {
                    if (body != null)
                        ResponseBodyPreview = Limit(body.ToString(), 4096);

                    break;
                }
            }

            Mark("Response received, StatusCode=" + StatusCode + ", BodyType=" + ResponseBodyType + ", BodyLength=" +
                 ResponseBodyLength);
        }

        public void SetBackupUrl(string backupUrl)
        {
            BackupUrl = backupUrl;
            Mark("Switch to backup url: " + backupUrl);
        }

        public void AttachTo(Exception exception, TypeInterface type, FailedList list, string nullValue,
            string errorType, string errorCode)
        {
            if (exception == null)
                return;

            UapiExceptionData.Add(exception, "UAPI.TraceId", TraceId);
            UapiExceptionData.Add(exception, "UAPI.StatusCode", list == null ? StatusCode : list.StatusCode);
            UapiExceptionData.Add(exception, "UAPI.NullValue", nullValue);
            UapiExceptionData.Add(exception, "UAPI.ErrorType", errorType);
            UapiExceptionData.Add(exception, "UAPI.ErrorCode", errorCode);
            UapiExceptionData.Add(exception, "UAPI.FailedReason", list == null ? null : list.FailedReason);
            UapiExceptionData.Add(exception, "UAPI.RequestUrl", RequestUrl);
            UapiExceptionData.Add(exception, "UAPI.BackupUrl", BackupUrl);
            UapiExceptionData.Add(exception, "UAPI.RequestType", RequestType);
            UapiExceptionData.Add(exception, "UAPI.ContentType", ContentType);
            UapiExceptionData.Add(exception, "UAPI.PostContentType", PostContentType);
            UapiExceptionData.Add(exception, "UAPI.PostContentLength", PostContentLength);
            UapiExceptionData.Add(exception, "UAPI.AuthenticationTokenSha256", TokenSha256);
            UapiExceptionData.Add(exception, "UAPI.ResultType", ResultType);
            UapiExceptionData.Add(exception, "UAPI.RawBodyType", RawBodyType);
            UapiExceptionData.Add(exception, "UAPI.ReasonPhrase", ReasonPhrase);
            UapiExceptionData.Add(exception, "UAPI.ResponseBodyType", ResponseBodyType);
            UapiExceptionData.Add(exception, "UAPI.ResponseBodyLength", ResponseBodyLength);
            UapiExceptionData.Add(exception, "UAPI.ResponseBodyPreview", ResponseBodyPreview);
            UapiExceptionData.Add(exception, "UAPI.ElapsedMs", _stopwatch.ElapsedMilliseconds);
            UapiExceptionData.Add(exception, "UAPI.TraceEvents", _events.ToString());

            var headers = (type == null ? null : type.Headers) ?? Headers ?? (list == null ? null : list.Headers);
            AttachHeaders(exception, headers);

            if (type != null)
            {
                UapiExceptionData.Add(exception, "UAPI.ResponseCode", type.code);
                UapiExceptionData.Add(exception, "UAPI.ResponseError", type.error);
                UapiExceptionData.Add(exception, "UAPI.ResponseMessage", type.message);
                UapiExceptionData.Add(exception, "UAPI.ResponseDetails", type.details);
            }

            if (OriginalException != null && !object.ReferenceEquals(OriginalException, exception))
            {
                UapiExceptionData.Add(exception, "UAPI.OriginalExceptionType", OriginalException.GetType().FullName);
                UapiExceptionData.Add(exception, "UAPI.OriginalExceptionMessage", OriginalException.Message);
                UapiExceptionData.Add(exception, "UAPI.OriginalExceptionStackTrace", OriginalException.StackTrace);
            }
        }

        private void AttachHeaders(Exception exception, Response.Headers headers)
        {
            if (headers == null)
                return;

            UapiExceptionData.Add(exception, "UAPI.Header.RequestID", headers.RequestID);
            UapiExceptionData.Add(exception, "UAPI.Header.Date", headers.Date);
            UapiExceptionData.Add(exception, "UAPI.Header.ContentType", headers.ContentType);
            UapiExceptionData.Add(exception, "UAPI.Header.ContentLength", headers.ContentLength);
            UapiExceptionData.Add(exception, "UAPI.Header.Server", headers.Server);
            UapiExceptionData.Add(exception, "UAPI.Header.XCacheStatus", headers.XCacheStatus);
            UapiExceptionData.Add(exception, "UAPI.Header.EdgeOneCacheStatus", headers.EdgeOneResourceCacheStatus);
            UapiExceptionData.Add(exception, "UAPI.Header.EdgeOneLogUUID", headers.EdgeOneLogUUID);
            UapiExceptionData.Add(exception, "UAPI.Header.RequestedCredits", headers.RequestedCredits);
            UapiExceptionData.Add(exception, "UAPI.Header.CreditsCharged", headers.CreditsCharged);
            UapiExceptionData.Add(exception, "UAPI.Header.CreditsRemaining", headers.CreditsRemaining);
            UapiExceptionData.Add(exception, "UAPI.Header.DebitStatus", headers.DebitStatus);
            UapiExceptionData.Add(exception, "UAPI.Header.RetryAfter", headers.RetryAfter);
            UapiExceptionData.Add(exception, "UAPI.Header.RateLimitPolicyRaw", headers.RateLimitPolicyRaw);
            UapiExceptionData.Add(exception, "UAPI.Header.RateLimitRaw", headers.RateLimitRaw);
            UapiExceptionData.Add(exception, "UAPI.Header.CreditsPricing", headers.CreditsPricing);
            UapiExceptionData.Add(exception, "UAPI.Header.IsVisitor", headers.IsVisitor);
            UapiExceptionData.Add(exception, "UAPI.Header.VisitorRate", headers.VisitorRate);
            UapiExceptionData.Add(exception, "UAPI.Header.VisitorQuotaRemaining", headers.VisitorQuotaRemaining);
            UapiExceptionData.Add(exception, "UAPI.Header.BillingQuotaLimit", headers.BillingQuotaLimit);
            UapiExceptionData.Add(exception, "UAPI.Header.BillingKeyRequestLimit", headers.BillingKeyRequestLimit);
            UapiExceptionData.Add(exception, "UAPI.Header.BillingKeyRequestIPLimit", headers.BillingKeyRequestIPLimit);
            UapiExceptionData.Add(exception, "UAPI.Header.ActivatedResourcePackagesCount",
                headers.ActivatedResourcePackagesCount);
            UapiExceptionData.Add(exception, "UAPI.Header.StopServiceWhenRemainingEmpty",
                headers.StopServiceWhenRemainingEmpty);
        }

        private void SetPostContent(object postContent)
        {
            if (postContent == null)
            {
                PostContentType = "<null>";
                return;
            }

            PostContentType = postContent.GetType().FullName;
            PostContentLength = postContent switch
            {
                string s => s.Length,
                byte[] bytes => bytes.Length,
                HttpContent _ => null,
                _ => Limit(postContent.ToString(), 2048).Length
            };
        }

        private void SetToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                TokenSha256 = "<empty>";
                return;
            }

            try
            {
                using var sha = System.Security.Cryptography.SHA256.Create();
                TokenSha256 = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(token.Trim())))
                    .Replace("-", "")
                    .ToLowerInvariant();
            }
            catch
            {
                TokenSha256 = "<failed>";
            }
        }

        private static string Limit(string value, int max)
        {
            if (string.IsNullOrEmpty(value))
                return value;
            return value.Length <= max ? value : value.Substring(0, max) + "...<truncated>";
        }
    }

    internal static partial class UapiExceptionData
    {
        public static void Add(Exception exception, string key, object value)
        {
            if (exception == null || string.IsNullOrWhiteSpace(key))
                return;

            try
            {
                var finalKey = key;
                var index = 1;
                while (exception.Data.Contains(finalKey))
                {
                    finalKey = key + "#" + index;
                    index++;
                }

                exception.Data[finalKey] = value == null ? "<null>" : Convert.ToString(value);
            }
            catch
            {
                // 诊断系统不能影响业务异常
            }
        }
    }

    internal static class UapiFailureReporter
    {
        public static FailedList Finalize<T>(FailedList list, T type, string nullValue, int statusCode,
            Exception preferredException, string errorType, string errorCode) where T : TypeInterface
        {
            if (list == null)
                return null;

            if (type != null && list.Headers == null)
                list.Headers = type.Headers;

            if (list.IsRequestSuccessfully)
            {
                UapiRequestTrace.Clear();
                return list;
            }

            if (list.FailedException == null && ShouldCreateException(statusCode, type, list))
            {
                list.FailedException = preferredException ??
                                       BuildDefaultException(statusCode, list.FailedReason, errorType, errorCode);
            }

            if (list.FailedException != null)
            {
                var trace = UapiRequestTrace.Current;
                if (trace != null)
                    trace.AttachTo(list.FailedException, type, list, nullValue, errorType, errorCode);
                else
                    AttachBasic(list.FailedException, type, list, nullValue, errorType, errorCode);

                var path = UapiDiagnosticReport.Save(list.FailedException);
                list.DiagnosticReportPath = path;
                try
                {
                    Rox.Runtimes.LogLibraries.WriteLog.Error("UAPI.DiagnosticReport", "诊断报告已生成: " + path);
                }
                catch
                {
                    // ignored
                }
            }

            UapiRequestTrace.Clear();
            return list;
        }

        private static bool ShouldCreateException<T>(int statusCode, T type, FailedList list) where T : TypeInterface
        {
            if (statusCode == -1 || statusCode == -2 || statusCode == -3)
                return true;
            return type == null;
        }

        private static Exception BuildDefaultException(int statusCode, string failedReason, string errorType,
            string errorCode)
        {
            return new InvalidOperationException(
                "UAPI 请求失败。StatusCode=" + statusCode +
                ", ErrorType=" + (errorType ?? "<null>") +
                ", ErrorCode=" + (errorCode ?? "<null>") +
                ", FailedReason=" + (failedReason ?? "<null>"));
        }

        private static void AttachBasic<T>(Exception exception, T type, FailedList list, string nullValue,
            string errorType, string errorCode)
            where T : TypeInterface
        {
            UapiExceptionData.Add(exception, "UAPI.StatusCode", list == null ? 0 : list.StatusCode);
            UapiExceptionData.Add(exception, "UAPI.NullValue", nullValue);
            UapiExceptionData.Add(exception, "UAPI.ErrorType", errorType);
            UapiExceptionData.Add(exception, "UAPI.ErrorCode", errorCode);
            UapiExceptionData.Add(exception, "UAPI.FailedReason", list == null ? null : list.FailedReason);

            if (type == null)
                return;

            UapiExceptionData.Add(exception, "UAPI.ResponseCode", type.code);
            UapiExceptionData.Add(exception, "UAPI.ResponseError", type.error);
            UapiExceptionData.Add(exception, "UAPI.ResponseMessage", type.message);
            UapiExceptionData.Add(exception, "UAPI.ResponseDetails", type.details);
        }
    }
}