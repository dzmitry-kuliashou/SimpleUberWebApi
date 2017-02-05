using Newtonsoft.Json;
using SimpleUber.Distribution.Attributes;
using SimpleUber.Distribution.Host.Installers;
using SimpleUber.Errors.Exception;
using SimpleUber.Services.Api.Services.ServiceLog.CommandHandlers;
using SimpleUber.Services.Api.Services.ServiceLog.CommandHandlers.Commands;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace SimpleUber.Distribution.Host.RequestAndResponseLogging
{
    public class RequestAndResponseLogger : DelegatingHandler
    {
        private readonly ICreateServiceLogCommandHandler _serviceLogCommandHandler;

        public RequestAndResponseLogger()
        {
            _serviceLogCommandHandler = WindsorContainer.Container.Resolve<ICreateServiceLogCommandHandler>();
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var requestBody = await request.Content.ReadAsStringAsync();
            var responseBody = string.Empty;

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            HttpResponseMessage result = null;

            try
            {
                result = await base.SendAsync(request, cancellationToken);
            }
            catch(ValidationException e)
            {
                stopwatch.Stop();

                var exception = e as ValidationException;
                var error = new ValidationErrorForClient(exception.Message, exception.ErrorCodes);
                var serializedErrorCodes = JsonConvert.SerializeObject(error);

                responseBody = serializedErrorCodes;

                SaveServiceLog(request, requestBody, responseBody, stopwatch.ElapsedMilliseconds);

                throw e;
            }
            catch(Exception e)
            {
                stopwatch.Stop();

                responseBody = "Some unexpected error";

                SaveServiceLog(request, requestBody, responseBody, stopwatch.ElapsedMilliseconds);

                throw e;
            }

            stopwatch.Stop();

            if (result.Content != null)
            {
                responseBody = await result.Content.ReadAsStringAsync();
            }

            SaveServiceLog(request, requestBody, responseBody, stopwatch.ElapsedMilliseconds);

            return result;
        }

        private void SaveServiceLog(HttpRequestMessage request, string requestBody, string responseBody, long durationTime)
        {
            var controllerType = GetControllerType(request);

            if(IsPartlySuppressedLogging(controllerType))
            {
                requestBody = string.Empty;
                responseBody = string.Empty;
            }

            var serviceLogCommand = new CreateServiceLogCommand
            {
                LogTime = DateTime.Now,
                DurationTime = durationTime,
                Request = requestBody,
                Response = responseBody,
                HandlerName = controllerType.Name,
                Method = request.Method.Method,
                Url = request.RequestUri.AbsolutePath,
                Host = request.RequestUri.Authority
            };

            _serviceLogCommandHandler.Execute(serviceLogCommand);
        }

        private Type GetControllerType(HttpRequestMessage request)
        {
            var controllerSelector = GlobalConfiguration.Configuration.Services.GetHttpControllerSelector();
            var controllerDescriptor = controllerSelector.SelectController(request);

            return controllerDescriptor.ControllerType;
        }

        private bool IsPartlySuppressedLogging(Type controllerType)
        {
            var partlySuppressedLoggingAttribute = controllerType
                .GetCustomAttributes(typeof(PartlySuppressedLoggingAttribute), true)
                .FirstOrDefault() as PartlySuppressedLoggingAttribute;

            return partlySuppressedLoggingAttribute != null;
        }
    }
}