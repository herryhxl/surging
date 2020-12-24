using Surging.Core.CPlatform.Exceptions;
using Surging.Core.CPlatform.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Surging.Core.KestrelHttpServer.Filters.Implementation
{
   public class CustomerExceptionFilterAttribute : IExceptionFilter
    {
        public Task OnException(ExceptionContext context)
        {
            object data = null;
            int statusCode = 400;
            if(context.Exception is ValidateException validate)
            {
                data = validate.ErrorData;
                statusCode = validate.ErrorCode;
            }
            context.Result = new HttpResultMessage<object>
            {
                Data = data,
                StatusCode = statusCode,
                IsSucceed = false,
                Message = context.Exception.Message
            };
            return Task.CompletedTask;
        }
    }
}
