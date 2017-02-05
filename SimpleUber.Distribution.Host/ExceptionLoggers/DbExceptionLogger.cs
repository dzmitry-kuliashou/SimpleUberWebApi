using SimpleUber.Services.Api.Services.ExceptionLog.CommandHandlers;
using SimpleUber.Services.Api.Services.ExceptionLog.CommandHandlers.Commands;
using System;
using System.Web.Http.ExceptionHandling;

namespace SimpleUber.Distribution.Host.ExceptionLoggers
{
    public class DbExceptionLogger : ExceptionLogger
    {
        private readonly ICreateExceptionLogCommandHandler _createExceptionLogCommandHandler;

        public DbExceptionLogger()
        {
            _createExceptionLogCommandHandler = Installers.WindsorContainer.Container.Resolve<ICreateExceptionLogCommandHandler>();
        }

        public override void Log(ExceptionLoggerContext context)
        {
            var command = new CreateExceptionLogCommand
            {
                DateTimeLogged = DateTime.Now,
                ExceptionMessage = context.Exception.Message,
                ExceptionTrace = context.Exception.StackTrace,
                Handler = context.Request.RequestUri.AbsolutePath
            };

            _createExceptionLogCommandHandler.Execute(command);
        }
    }
}