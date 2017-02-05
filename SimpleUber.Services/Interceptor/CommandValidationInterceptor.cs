using Castle.DynamicProxy;
using FluentValidation;
using SimpleUber.Errors.ErrorCodes;
using SimpleUber.Services.Attributes;
using SimpleUber.Services.Installers;
using System;
using System.Linq;
using ValidationException = SimpleUber.Errors.Exception.ValidationException;

namespace SimpleUber.Services.Interceptor
{
    public class CommandValidationInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var validationRequiredAttribute = invocation.InvocationTarget.GetType()
                .GetCustomAttributes(typeof(ValidationRequiredAttribute), true)
                .FirstOrDefault() as ValidationRequiredAttribute;

            if(validationRequiredAttribute != null)
            {
                var commandTypeParam = invocation.Arguments[0].GetType();
                var commandType = typeof(IValidator<>).MakeGenericType(commandTypeParam);
                var validator = WindsorContainer.Container.Resolve(commandType) as IValidator;

                var validationResult = validator.Validate(new ValidationContext(invocation.Arguments[0]));

                if(validationResult.Errors.Count > 0)
                {
                    var errorCodes = validationResult.Errors.Select(x => new ErrorCode(int.Parse(x.ErrorCode), x.ErrorMessage)).ToList();

                    throw new ValidationException(errorCodes);
                }
            }

            invocation.Proceed();
        }
    }
}
