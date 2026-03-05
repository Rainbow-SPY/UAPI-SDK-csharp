using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using Rox.Runtimes;
using static Rox.Runtimes.LocalizedString;
using Convert = System.Convert;

namespace UAPI
{
    public partial class Interface
    {
        /// <summary>
        /// 获取指定程序集的PublicKey 公钥
        /// </summary>
        /// <param name="AssemblyPath">程序集路径</param>
        /// <returns>Public Key Token</returns>
        public static string GetAssemblyPublicKeyToken(string AssemblyPath)
        {
            try
            {
                // 定义程序集名称和路径
                const string assemblyName = "Rox.Runtimes.dll";
                var assemblyPath =
                    Path.Combine(
                        Directory.GetParent(Process.GetCurrentProcess()?.MainModule?.FileName ??
                                            Directory.GetCurrentDirectory())?.FullName ??
                        Directory.GetCurrentDirectory(),
                        assemblyName);

                // 检查文件是否存在
                if (File.Exists(assemblyPath))
                    return BitConverter.ToString(Assembly.LoadFrom(assemblyPath).GetName().GetPublicKeyToken())
                        .Replace("-", "")
                        .ToLower(); // 转换为小写，符合常规格式
                LogLibraries.WriteLog.Info($"错误：未找到程序集文件 {assemblyPath}");
                return null;
            }
            catch (FileLoadException ex)
            {
                LogLibraries.WriteLog.Error($"加载程序集失败：{_Exception_With_xKind("GetAssemblyPublicKeyToken", ex)}");
            }
            catch (BadImageFormatException ex)
            {
                LogLibraries.WriteLog.Error(
                    $"程序集格式错误（非.NET程序集）：{_Exception_With_xKind("GetAssemblyPublicKeyToken", ex)}");
            }
            catch (Exception ex)
            {
                LogLibraries.WriteLog.Error($"发生未知错误：{_Exception_With_xKind("GetAssemblyPublicKeyToken", ex)}");
            }

            return null;
        }

        /// <summary>
        /// 字符串转十六进制
        /// </summary>
        /// <param name="hexContent">字符串</param>
        /// <returns>十六进制字符串</returns>
        public static string ToHex(object hexContent)
        {
            if (string.IsNullOrEmpty(hexContent.ToString()))
                return "";

            var restoredCsv = new StringBuilder();

            foreach (var row in hexContent.ToString().Split(new[] { '\n' }, StringSplitOptions.None))
            {
                var restoredRow = new StringBuilder();

                foreach (var cell in row.Split(','))
                {
                    string ret;
                    if (string.IsNullOrEmpty(cell))
                        ret = "";
                    else
                    {
                        if (cell.Length % 2 != 0)
                            throw new FormatException($"无效的十六进制字符串：{cell}（长度必须为偶数）");

                        var bytes = new byte[cell.Length / 2];
                        for (var i = 0; i < bytes.Length; i++)
                        {
                            bytes[i] = Convert.ToByte(cell.Substring(i * 2, 2), 16);
                        }

                        ret = Encoding.UTF8.GetString(bytes);
                    }

                    restoredRow.Append(ret).Append(',');
                }

                if (restoredRow.Length > 0)
                    restoredRow.Length--;

                restoredCsv.AppendLine(restoredRow.ToString());
            }

            return restoredCsv.ToString();
        }

        public class Security
        {
            private static string DecryptAPIKey(string EncryptedKey) =>
                ToHex(
                    Encoding.UTF8.GetString(Convert.FromBase64String(Convert.ToByte(EncryptedKey).ToString())));

            private static string EncryptAPIKey(string PublicTokenKey)
            {
                var a = ToHex(PublicTokenKey);
                var b = Encoding.UTF8.GetString(a);
            }
        }
    }
}