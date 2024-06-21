using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.ModelsCore.Exceptions
{
    public class AuthCustomException : IAuthException
    {
        public string ErrorDescription { get; set; }

        public int ErrorCode { get; set; } 

        public AuthCustomException(string errorDescription, int errorCode)
        {
            ErrorDescription = errorDescription;
            ErrorCode = errorCode;
        }
    }
}
