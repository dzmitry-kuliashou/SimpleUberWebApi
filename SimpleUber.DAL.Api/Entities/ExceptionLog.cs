using System;

namespace SimpleUber.DAL.Api.Entities
{
    public class ExceptionLog : EFEntity
    {
        public DateTime DateTimeLogged { get; set; }

        public string ExceptionMessage { get; set; }

        public string ExceptionTrace { get; set; }

        public string Handler { get; set; }
    }
}
