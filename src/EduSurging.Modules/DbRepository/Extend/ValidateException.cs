using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFRepository.Extend
{
    public class ValidateException : Exception
    {
        public int Code { get; private set; }
        public string Msg { get; private set; }
        public Object Obj { get; private set; }
        public ValidateException(string msg, int code = 1, object obj = null) : base(msg)
        {
            this.Code = code;
            this.Msg = msg;
            this.Obj = obj;
        }
    }
}
