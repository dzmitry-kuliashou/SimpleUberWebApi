using SimpleUber.Services.Api.Common;
using SimpleUber.Services.Api.Services.ExceptionLog.CommandHandlers.Commands;

namespace SimpleUber.Services.Api.Services.ExceptionLog.CommandHandlers
{
    public interface ICreateExceptionLogCommandHandler : ICommandHandler<CreateExceptionLogCommand>
    {
    }
}
