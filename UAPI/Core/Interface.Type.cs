using System;
using Newtonsoft.Json;

namespace UAPI
{
    public partial class Type
    {
        /// <summary>
        /// 自定义类的接口公共属性基类
        /// </summary>
        public class TypeInterface
        {
            /// <summary>
            /// 错误代码
            /// </summary>
            [JsonProperty("code")]
            public string code { get; set; }

            /// <summary>
            /// 错误代码
            /// </summary>
            [JsonProperty("error")]
            public string error { get; set; }

            /// <summary>
            /// 错误信息
            /// </summary>
            [JsonProperty("message")]
            public string message { get; set; }

            /// <summary>
            /// 详细错误信息
            /// </summary>
            [JsonProperty("details")]
            public string details { get; set; }

            /// <summary>
            /// 响应头
            /// </summary>
            public Response.Headers Headers { get; set; }
        }

        /// <summary/>
        public class FailedList : TypeInterface
        {
            /// <summary>
            /// Http 状态码
            /// </summary>
            public int StatusCode { get; set; }

            /// <summary>
            /// 请求是否成功
            /// </summary>
            public bool IsRequestSuccessfully { get; set; }

            /// <summary>
            /// 错误原因
            /// </summary>
            public string FailedReason { get; set; }

            /// <summary>
            /// 错误引发的异常
            /// </summary>
            public Exception FailedException { get; set; }

            /// <summary>
            /// 响应数据
            /// </summary>
            public object Result { get; set; }

            /// <summary>
            /// UAPI 诊断报告文件路径。仅在 FailedException 被创建并写入报告时有值。
            /// </summary>
            public string DiagnosticReportPath { get; set; }
        }

        /// <summary>
        /// 非 JSON Body 的统一返回包装，用于 string / byte[] 等原始响应体，同时保留 Headers。
        /// </summary>
        public class BodyResult<TBody> : TypeInterface
        {
            /// <summary>
            /// 响应 Body
            /// </summary>
            public TBody Result { get; set; }
        }
    }
}