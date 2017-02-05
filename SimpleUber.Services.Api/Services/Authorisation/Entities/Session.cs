using System;

namespace SimpleUber.Services.Api.Services.Authorisation.Entities
{
    public class Session
    {
        public Guid Token { get; set; }

        public DateTime TokenExpired { get; set; }
    }
}
