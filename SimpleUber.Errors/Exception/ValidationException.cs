using SimpleUber.Errors.ErrorCodes;
using System.Collections.Generic;

namespace SimpleUber.Errors.Exception
{
    public class ValidationException : System.Exception
    {
        public List<ErrorCode> ErrorCodes { get; private set; }

        public ValidationException(List<ErrorCode> errorCodes) : base("ValidationException")
        {
            ErrorCodes = errorCodes;
        }
    }
}
