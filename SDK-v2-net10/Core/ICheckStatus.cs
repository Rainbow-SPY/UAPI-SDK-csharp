using UAPI.v2.lib;

namespace UAPI.v2.Core;

internal class ICheckStatus
{
    internal static UPSException CheckStatus(UPSException _exp)
    {
        switch (_exp.StatusCode)
        {
            case 200:
                ILogs.Info("请求成功");
                _exp.IsRequestSuccessfully = true;
                return _exp;
            case 302:
                ILogs.Info("链接已重定向, 请求成功");
                _exp.IsRequestSuccessfully = true;
                return _exp;
            case 400:
                switch (GetErrorOrCode(_exp))
                {
                    case "CONVERSION_FAILED":
                        ILogs.Error(
                            $"传递的参数 {_exp.Model._dir} 在转换时失败! \n\t{_ERROR_CODE}: {CONVERSION_FAILED}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}");
                        _exp.FailedReason = CONVERSION_FAILED;
                        break;
                    case "FILE_REQUIRED":
                        ILogs.Error(
                            $"{NullValue ?? "%s"} 缺少文件参数, 没有找到上传的文件! \n\t{_ERROR_CODE}: {FILE_REQUIRED}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}");
                        _exp.FailedReason = FILE_REQUIRED;
                        break;
                    case "INVALID_PARAMETER":
                        ILogs.Error(
                            $"{NullValue ?? "%s"} 参数校验失败!\n\t{_ERROR_CODE}: {INVALID_PARAMETER}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}");
                        _exp.FailedReason = INVALID_PARAMETER;
                        break;
                    case "INVALID_PARAMS":
                        ILogs.Error(
                            $"{NullValue ?? "%s"} 参数校验失败!\n\t{_ERROR_CODE}: {INVALID_PARAMS}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}");
                        _exp.FailedReason = INVALID_PARAMS;
                        break;
                    case "UNSUPPORTED_FORMAT":
                        ILogs.Error(
                            $"{NullValue ?? "%s"} 的文件、文本或参数格式不支持!\n\t{_ERROR_CODE}: {UNSUPPORTED_FORMAT}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}");
                        _exp.FailedReason = UNSUPPORTED_FORMAT;
                        break;
                }

                return _exp;
            case 401:
                ILogs.Error("UnAuthorized",
                    $"未经授权的操作!\n\t{_ERROR_CODE}: {UNAUTHORIZED}, 错误信息: {GetMessageOrDetails(Type)}\n\t{GetFailedReportDetails(Type)}");
                _exp.FailedException = new UnauthorizedAccessException("未经授权的操作");
                _exp.FailedReason = UNAUTHORIZED;
                return _exp;
            case 402:
                ILogs.Error(
                    $"账户积分不足, 无法完成请求!\n\t{_ERROR_CODE}: {INSUFFICIENT_CREDITS}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                _exp.FailedReason = INSUFFICIENT_CREDITS;
                return _exp;
            case 403:
                ILogs.Warning(
                    $"您已被限制请求, 因 请求量过大!\n\t:{_ERROR_CODE}: HttpClient 403, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                _exp.FailedReason = "Too Much Request";
                return _exp;
            case 404:
                switch (GetErrorOrCode(Type))
                {
                    case "AVATAR_NOT_FOUND":
                        ILogs.Error(
                            $"未找到 {NullValue ?? "%s"} 请求的头像资源!\n\t{_ERROR_CODE}: {AVATAR_NOT_FOUND}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                        _exp.FailedReason = AVATAR_NOT_FOUND;
                        break;
                    case "NOT_FOUND":
                        ILogs.Error(
                            $"未找到 {NullValue ?? "%s"} 请求的资源!\n\t{_ERROR_CODE}: {NOT_FOUND}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                        "NOT_FOUND");
                        _exp.FailedReason = NOT_FOUND;
                        break;
                    case "NO_MATCH":
                        ILogs.Warning(
                            $"没有查询到 {NullValue ?? "%s"} 相关的结果!\n\t{_ERROR_CODE}: {NO_MATCH}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                        _exp.FailedReason = NO_MATCH;
                        break;
                    case "NO_TRACKING_DATA":
                        ILogs.Warning(
                            $"没有查询到 {NullValue ?? "%s"} 的物流轨迹!\n\t{_ERROR_CODE}: {NO_TRACKING_DATA}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                        _exp.FailedReason = NO_TRACKING_DATA;
                        break;
                    case "RECOGNITION_FAILED":
                        ILogs.Error(
                            $"{NullValue ?? "%s"} 识别失败!\n\t{_ERROR_CODE}: {RECOGNITION_FAILED}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                        _exp.FailedReason = RECOGNITION_FAILED;
                        break;
                    case "TIMEZONE_NOT_FOUND":
                        ILogs.Error(
                            $"时区查询失败! 请确认 {NullValue ?? "%s"} 是标准合法的 IANA 时区数据库名称\n\t{_ERROR_CODE}: {TIMEZONE_NOT_FOUND}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                        _exp.FailedReason = TIMEZONE_NOT_FOUND;
                        break;
                    case "UNSUPPORTED_CARRIER":
                        ILogs.Error(
                            $"不支持的物流公司! 请确认 {NullValue ?? "%s"} 是存在的物流公司名称\n\t{_ERROR_CODE}: {UNSUPPORTED_CARRIER}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                        _exp.FailedReason = UNSUPPORTED_CARRIER;
                        break;
                }

                return _exp;
            case 413:
                ILogs.Error(
                    $"请求量过大, 可能是由于 {NullValue ?? "%s"} 的上传体积过大!\n\t{_ERROR_CODE}: {REQUEST_ENTITY_TOO_LARGE}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                _exp.FailedReason = REQUEST_ENTITY_TOO_LARGE;
                return _exp;
            case 429:
                switch (GetErrorOrCode(Type))
                {
                    case "SERVICE_BUSY":
                        ILogs.Error(
                            $"因请求量太大, 限制了您的请求!\n\t{_ERROR_CODE}: {SERVICE_BUSY}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                        _exp.FailedReason = SERVICE_BUSY;
                        break;
                    case "VISITOR_MONTHLY_QUOTA_EXHAUSTED":
                        ILogs.Error(
                            $"访客额度已消耗殆尽! 请尝试购买资源包或等待下个免费额度重置时间.\n\t{_ERROR_CODE}: {VISITOR_MONTHLY_QUOTA_EXHAUSTED}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                        _exp.FailedReason = VISITOR_MONTHLY_QUOTA_EXHAUSTED;
                        break;
                    default:
                        ILogs.Error(
                            $"未知错误, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}\n\tHttpClient return 429");
                        _exp.FailedReason = "HttpClient return 429";
                        _exp.FailedException = _Exception;
                        break;
                }

                return _exp;
            case 500:
                switch (GetErrorOrCode(Type))
                {
                    case "FILE_OPEN_ERROR":
                        ILogs.Error(
                            $"服务器处理文件 {NullValue ?? "%s"} 时发生未知的异常, 请联系管理员解决问题!\n\t{_ERROR_CODE}: {FILE_OPEN_ERROR}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                        _exp.FailedReason = FILE_OPEN_ERROR;
                        _exp.FailedException = new FileOpenFailed();
                        return _exp;
                    case "PHONE_INFO_FAILED":
                        ILogs.Error(
                            $"手机号归属地查询失败或上游服务查询失败, 请确认 {NullValue ?? "%s"} 参数为中国大陆地区合法的11位手机号!\n\t{_ERROR_CODE}: {PHONE_INFO_FAILED}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                        _exp.FailedReason = PHONE_INFO_FAILED;
                        return _exp;
                    default:
                        ILogs.Error(
                            $"服务器内部错误, 请联系管理员或反馈工单, {_ERROR_CODE}: {INTERNAL_SERVER_ERROR}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                        _exp.FailedException = new General.UAPIServerDown(
                            $"服务器内部错误, 请联系管理员或反馈工单, {_ERROR_CODE}: {INTERNAL_SERVER_ERROR}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                        _exp.FailedReason = INTERNAL_SERVER_ERROR;
                        return _exp;
                }

            case 502:
                ILogs.Error(
                    $"{_Error_Type ?? "%s"} 上游 API请求错误, {(string.IsNullOrEmpty(Error_Code) ? "" : $"{_ERROR_CODE}: {Error_Code}")}, 错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                _exp.FailedException = _Exception;
                _exp.FailedReason = "Upstream Error";
                return _exp;
            case 503:
                ILogs.Error(
                    $"当前指定的服务 {_Error_Type ?? "%s"} 不可用, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {_UAPI_Service_Unavailable},错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                _exp.FailedException = new General.UAPIServiceUnavailable(
                    $"当前指定的服务 {_Error_Type} 不可用, 请联系 UAPI 管理员或反馈工单, {_ERROR_CODE}: {_UAPI_Service_Unavailable},错误信息: {GetMessageOrDetails(Type) ?? ""}\n\t{GetFailedReportDetails(Type) ?? ""}");
                _exp.FailedReason = _UAPI_Service_Unavailable;
                return _exp;
            case -1:
                ILogs.Error("请求失败, 请查找错误并提交日志给工作人员");
                _exp.FailedReason = "Request Failed";
                return _exp;
            case -2:
                ILogs.Error("请求失败, 请查找错误并提交日志给工作人员\n\t错误原因: 基础性请求出错或请求的任务超时被取消");
                _exp.FailedException = new HttpRequestException("");
                _exp.FailedReason = "Http Request Failed";
                return _exp;
            case -3:
                ILogs.Error(
                    $"JSON反序列化失败！请重试或反馈工单给工作人员, {_ERROR_CODE}: {JSON_SERIALIZATION_ERROR}\n\t错误原因: JSON 反序列化失败");
                _exp.FailedException = new JsonSerializationException();
                _exp.FailedReason = JSON_SERIALIZATION_ERROR;
                return _exp;
            default:
                ILogs.Error("未知错误");
                _exp.FailedException = _Exception;
                _exp.FailedReason = _UNKNOW_ERROR;
                return _exp;
        }
    }

    internal static string? GetErrorOrCode(UPSException _exp)
        => _exp.Code ?? _exp.Error;

    internal static string GetMessageOrDetails(UPSException _exp)
        => _exp.Details ?? _exp.Message ?? "未知原因";
}