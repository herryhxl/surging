using System;
using System.Collections.Generic;
using System.Text;

namespace Surging.Core.Protocol.Http
{
   public enum StatusCode
    {
        SystemError = 0,
        Success =200,
        RequestError =400,
        AuthorizationFailed=401,
    }
}
