using SimpleUber.Errors.ErrorCodes;
using System.Collections.Generic;

namespace SimpleUber.Errors.Exception
{
    public class ValidationErrorForClient
    {
        public string Message { get; private set; }

        public List<ErrorCode> ErrorCodes { get; private set; }

        public ValidationErrorForClient(string message, List<ErrorCode> errorCodes)
        {
            Message = message;
            ErrorCodes = errorCodes;
        }
    }
}
