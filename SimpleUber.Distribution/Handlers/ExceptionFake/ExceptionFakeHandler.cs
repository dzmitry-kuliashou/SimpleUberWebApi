using System;
using SimpleUber.Distribution.Api.Services.ExceptionFake;
using System.Web.Http;

namespace SimpleUber.Distribution.Handlers.ExceptionFake
{
    public class ExceptionFakeHandler : ApiController, IExceptionFake
    {
        [HttpPost]
        [Route("api/exceptionfake/new")]
        public void CreateNewSomething([FromBody]string someWord)
        {
            throw new Exception("Ha-ha-ha");
        }
    }
}
