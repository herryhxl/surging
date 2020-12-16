using System;

namespace Surging.Core.CPlatform.Exceptions
{
    /// <summary>
    /// Model、DTO等对象校验异常
    /// </summary>
    public class ValidateException : CPlatformException
    {
        /// <summary>
        /// 错误码，前端用户可根据不同的错误码处理不同的业务
        /// </summary>
        public int ErrorCode { private set; get; }
        /// <summary>
        /// 错误时返回的数据
        /// </summary>
        public object ErrorData { private set; get; }
        /// <summary>
        /// 初始构造函数
        /// </summary>
        /// <param name="message">异常信息</param>
        /// <param name="innerException">内部异常</param>
        public ValidateException(string message, int errorCode = 0, object errorData = null, Exception innerException = null) : base(message, innerException)
        {
            ErrorCode = errorCode;
            ErrorData = errorData;
        }
    }
}
