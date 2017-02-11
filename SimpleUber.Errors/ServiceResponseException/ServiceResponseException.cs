using SimpleUber.Errors.ErrorCodes;
using System.Collections.Generic;

namespace SimpleUber.Errors.ServiceResponseException
{
    public class ServiceResponseException : System.Exception
    {
        public List<ErrorCode> ErrorCodes { get; private set; }

        public ServiceResponseException(List<ErrorCode> errorCodes)
        {
            ErrorCodes = errorCodes;
        }
    }
}
