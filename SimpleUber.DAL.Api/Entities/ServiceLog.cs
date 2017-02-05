using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleUber.DAL.Api.Entities
{
    public class ServiceLog : EFEntity
    {
        [Required]
        public DateTime LogTime { get; set; }

        [Required]
        public double DurationTime { get; set; }

        public string Request { get; set; }

        public string Response { get; set; }

        public string HandlerName { get; set; }

        public string Method { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Host { get; set; }
    }
}
