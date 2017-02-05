using SimpleUber.Services.Api.Services.ExceptionLog.CommandHandlers;
using SimpleUber.Services.Api.Services.ExceptionLog.CommandHandlers.Commands;
using SimpleUber.Services.Services.ExceptionLog.Mappers;
using SimpleUber.Services.Services.ExceptionLog.Writers;

namespace SimpleUber.Services.Services.ExceptionLog.CommandHandlers
{
    public class CreateExceptionLogCommandHandler : ICreateExceptionLogCommandHandler
    {
        private readonly IExceptionLogWriter _writer;

        public CreateExceptionLogCommandHandler(
            IExceptionLogWriter writer)
        {
            _writer = writer;
        }

        public void Execute(CreateExceptionLogCommand command)
        {
            var exceptionLog = ExceptionLogMapperRegistrar.GetMapper()
                .Map<CreateExceptionLogCommand, SimpleUber.DAL.Api.Entities.ExceptionLog>(command);

            _writer.CreateExceptionLog(exceptionLog);
        }
    }
}
