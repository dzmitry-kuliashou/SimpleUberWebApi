using System;

namespace SimpleUber.Services.Api.Services.ExceptionLog.CommandHandlers.Commands
{
    public class CreateExceptionLogCommand
    {
        public DateTime DateTimeLogged { get; set; }

        public string ExceptionMessage { get; set; }

        public string ExceptionTrace { get; set; }

        public string Handler { get; set; }
    }
}
