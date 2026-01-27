namespace UAPI.IException
{
    public class General
    {
        public const string _UAPI_Unknown_Exception = "UAPI_Unknown_Exception";

        public static readonly string _UAPI_Server_Down =
            $"UAPI_Server_Down;HttpClient return 500;{Rox.Runtimes.GetSystemInfo.OSName} - {Rox.Runtimes.GetSystemInfo.OSArchitecture} - {Rox.Runtimes.GetSystemInfo.OSBuildNumber};{Rox.Runtimes.GetSystemInfo.SystemLanguage}";

        /// <summary>
        /// 未知异常, 请联系管理员或反馈工单 <see href="https://uapis.cn/docs/getting-started/about-us"/>
        /// </summary>
        public class UAPIUnknowException : System.Exception
        {
            public UAPIUnknowException() : base()
            {
            }

            public UAPIUnknowException(
                string message = @"未知异常, 请联系管理员或反馈工单: https://uapis.cn/docs/getting-started/about-us") : base(message)
            {
            }

            public UAPIUnknowException(string message, System.Exception inner) : base(message, inner)
            {
            }
        }

        public class UAPIServerDown : System.Exception
        {
            public UAPIServerDown() : base()
            {
            }

            public UAPIServerDown(string message) : base(message)
            {
            }

            public UAPIServerDown(string message, System.Exception inner) : base(message, inner)
            {
            }
        }
    }
}