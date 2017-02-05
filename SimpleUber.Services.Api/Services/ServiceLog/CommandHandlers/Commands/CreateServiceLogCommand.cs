using System;

namespace SimpleUber.Services.Api.Services.ServiceLog.CommandHandlers.Commands
{
    public class CreateServiceLogCommand
    {
        public DateTime LogTime { get; set; }

        public double DurationTime { get; set; }

        public string Request { get; set; }

        public string Response { get; set; }

        public string HandlerName { get; set; }

        public string Method { get; set; }

        public string Url { get; set; }

        public string Host { get; set; }
    }
}
