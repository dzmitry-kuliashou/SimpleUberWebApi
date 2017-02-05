using SimpleUber.Services.Api.Services.ServiceLog.CommandHandlers;
using SimpleUber.Services.Api.Services.ServiceLog.CommandHandlers.Commands;
using SimpleUber.Services.Services.ServiceLog.Mappers;
using SimpleUber.Services.Services.ServiceLog.Writers;

namespace SimpleUber.Services.Services.ServiceLog.CommandHandlers
{
    public class CreateServiceLogCommandHandler : ICreateServiceLogCommandHandler
    {
        private readonly IServiceLogWriter _serviceLogWriter;

        public CreateServiceLogCommandHandler(
            IServiceLogWriter serviceLogWriter)
        {
            _serviceLogWriter = serviceLogWriter;
        }

        public void Execute(CreateServiceLogCommand command)
        {
            var serviceLog = ServiceLogMapperRegistrar.GetMapper()
                .Map<CreateServiceLogCommand, SimpleUber.DAL.Api.Entities.ServiceLog>(command);

            _serviceLogWriter.CreateServiceLog(serviceLog);
        }
    }
}
