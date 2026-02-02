namespace UAPI.IException
{
    /// <summary>
    /// github综合相关异常
    /// </summary>
    public class github
    {
        internal const string _Github_ServiceError = "Github API Error;HttpClient return 502";
        /// <summary>
        /// 上游 GitHub API 出错或不可用
        /// </summary>
        public class GithubAPIServiceError : System.Exception
        {
            /// <summary>
            /// 上游 GitHub API 出错或不可用
            /// </summary>
            public GithubAPIServiceError() : base()
            {
            }

            /// <summary>
            /// 上游 GitHub API 出错或不可用
            /// </summary>
            /// <param name="message"></param>
            public GithubAPIServiceError(string message) : base(message)
            {
            }

            /// <summary>
            /// 上游 GitHub API 出错或不可用
            /// </summary>
            /// <param name="message"></param>
            /// <param name="innerException"></param>
            public GithubAPIServiceError(string message, System.Exception innerException) : base(message,
                innerException)
            {
            }
        }
    }
}