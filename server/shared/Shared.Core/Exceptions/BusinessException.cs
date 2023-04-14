using System;

namespace Shared.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public string Code { get;  }
        public string ExceptionMessage { get;  }

        public BusinessException(string code,string message = "")
        {
            Code = code;
            ExceptionMessage = message;
        }
    }
}
