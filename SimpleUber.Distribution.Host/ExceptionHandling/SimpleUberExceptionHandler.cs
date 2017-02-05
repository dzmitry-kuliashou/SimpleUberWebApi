using Newtonsoft.Json;
using SimpleUber.Errors.Exception;
using System.Web.Http.ExceptionHandling;

namespace SimpleUber.Distribution.Host.ExceptionHandling
{
    public class SimpleUberExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            if (context.Exception is ValidationException)
            {
                var exception = context.Exception as ValidationException;
                var error = new ValidationErrorForClient(exception.Message, exception.ErrorCodes);
                var serializedErrorCodes = JsonConvert.SerializeObject(error);

                context.Result = new TextPlainErrorResult
                {
                    Request = context.ExceptionContext.Request,
                    Content = serializedErrorCodes
                };
            }
            else
            {
                context.Result = new TextPlainErrorResult
                {
                    Request = context.ExceptionContext.Request,
                    Content = "O..o..o. Something wrong :("
                };
            }
        }
    }
}