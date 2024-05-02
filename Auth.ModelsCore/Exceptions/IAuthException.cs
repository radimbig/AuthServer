using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.ModelsCore.Exceptions
{
    public interface IAuthException
    {
        public string ErrorDescription { get;}

        public int ErrorCode { get;}
    }
}
