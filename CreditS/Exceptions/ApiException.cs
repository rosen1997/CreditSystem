using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Exceptions
{
    public class ApiException
    {
        public int StatusCode { get; }
        public string Message { get; }
        public string Description { get; }

        public ApiException(int StatusCode, string Message = null, string Description = null)
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
            this.Description = Description;
        }
    }
}
