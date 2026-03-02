using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
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
                        Directory.GetParent(Process.GetCurrentProcess().MainModule?.FileName ??
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
        
        internal class Security
        {
            internal static string DecryptAPIKey(string EncryptedKey) =>
                Encoding.UTF8.GetString(Convert.FromBase64String(Convert.ToBase64String(_0x7e(_0x2d(EncryptedKey), 5))));


            internal static string EncryptAPIKey(string PublicTokenKey) => _0x5a(
                    _0x0a(
                        Convert.FromBase64String(Convert.ToBase64String(Encoding.UTF8.GetBytes(PublicTokenKey))),
                        5))
                .Replace("0x", "").Replace(" ", "");

            private static byte[] _0x0a(byte[] bytes, int shift)
            {
                if (bytes == null || bytes.Length == 0 || shift <= 0) return bytes;

                shift = shift % bytes.Length; // 处理移位次数超过数组长度的情况
                if (shift == 0) return bytes;

                var result = new byte[bytes.Length];
                // 后shift个字节移到头部
                Array.Copy(bytes, bytes.Length - shift, result, 0, shift);
                // 前n-shift个字节移到尾部
                Array.Copy(bytes, 0, result, shift, bytes.Length - shift);

                return result;
            }

            private static string _0x5a(byte[] bytes) =>
                string.Join(" ", bytes.Select(b => $"0x{b:X2}"));

            private static byte[] _0x2d(string hexStr)
            {
                if (string.IsNullOrEmpty(hexStr) || hexStr.Length % 2 != 0)
                    throw new ArgumentException("无效的十六进制字符串");

                // 每2个字符转换为1个字节
                return Enumerable.Range(0, hexStr.Length / 2)
                    .Select(i => Convert.ToByte(hexStr.Substring(i * 2, 2), 16))
                    .ToArray();
            }

            private static byte[] _0x7e(byte[] bytes, int shift)
            {
                if (bytes == null || bytes.Length == 0 || shift <= 0) return bytes;
                shift = shift % bytes.Length;
                if (shift == 0) return bytes;

                var result = new byte[bytes.Length];
                // 左移shift位：前shift个字节移到尾部，其余移到头部
                Array.Copy(bytes, shift, result, 0, bytes.Length - shift);
                Array.Copy(bytes, 0, result, bytes.Length - shift, shift);
                return result;
            }
        }
    }
}