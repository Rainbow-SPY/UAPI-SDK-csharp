namespace UAPI.Extensions
{
    /// <summary />
    public static class Type
    {
        /// <summary>
        /// 获取 TypeInterface 基类的 code 错误代码值
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>错误代码</returns>
        public static string GetTypeCode<T>(this T value) where T : UAPI.Type.TypeInterface => value.code;

        /// <summary>
        /// 获取 TypeInterface 基类的 error 错误代码值
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>错误代码</returns>
        public static string GetTypeError<T>(this T value) where T : UAPI.Type.TypeInterface => value.error;

        /// <summary>
        /// 获取 TypeInterface 基类的 message 消息值
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>详细错误信息</returns>
        public static string GetTypeMessage<T>(this T value) where T : UAPI.Type.TypeInterface => value.message;

        /// <summary>
        /// 获取 TypeInterface 基类的 details 消息值
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>详细错误信息</returns>
        public static string GetTypeDetails<T>(this T value) where T : UAPI.Type.TypeInterface => value.details;

        /// <summary>
        /// 获取 TypeInterface 基类的 ResponseHeaders 请求头
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static UAPI.Type.Response.Headers GetTypeResponseHeader<T>(this T value)
            where T : UAPI.Type.TypeInterface => value.Headers;

        /// <summary>
        /// 获取 TypeInterface 基类的 ResponseHeaders 请求头的 RequestID 请求ID值
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>请求ID值</returns>
        public static string GetResultRequestID<T>(this T value) where T : UAPI.Type.TypeInterface =>
            value.Headers.RequestID;

        /// <summary>
        /// 获取 TypeInterface 基类的 ResponseHeaders 请求头的 CreditsCharged 实际扣除积分值
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>实际扣除积分</returns>
        public static int GetResultCreditsCharged<T>(this T value) where T : UAPI.Type.TypeInterface
            => value.Headers.CreditsCharged;

        /// <summary>
        /// 获取 TypeInterface 基类的 ResponseHeaders 请求头的 CreditsRemaining 剩余积分值
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>剩余积分</returns>
        public static int GetResultCreditsRemaining<T>(this T value) where T : UAPI.Type.TypeInterface
            => value.Headers.CreditsRemaining;

        /// <summary>
        /// 获取 TypeInterface 基类的 ResponseHeaders 请求头的 IsHITCache 是否命中缓存值
        /// </summary>
        /// <param name="value"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns><see langword="bool"/></returns>
        public static bool GetResultIsHITCache<T>(this T value) where T : UAPI.Type.TypeInterface
            => value.Headers.IsHITCache;
    }
}