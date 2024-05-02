using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.ModelsCore.Exceptions
{
    public class UserAlreadyExistException : Exception, IAuthException
    {
        private string _errorDescription;
        public UserAlreadyExistException(string des) { _errorDescription = des; }

        public UserAlreadyExistException() { _errorDescription = "User already exists"; }
        public string ErrorDescription => _errorDescription;

        public int ErrorCode => 400;
    }
}
