using SimpleUber.Distribution.Api.Services.Authorization;
using SimpleUber.Distribution.Attributes;
using SimpleUber.Services.Api.Services.Authorisation.CommandHandlers;
using SimpleUber.Services.Api.Services.Authorisation.CommandHandlers.Commands;
using SimpleUber.Services.Api.Services.Authorisation.Entities;
using System;
using System.Web.Http;

namespace SimpleUber.Distribution.Handlers.Authorization
{
    [PartlySuppressedLogging]
    public class AuthorizationHandler : ApiController, IAuthorization
    {
        private readonly ICreateSessionCommandHandler _createSessionCommandHandler;

        public AuthorizationHandler(
            ICreateSessionCommandHandler createSessionCommandHandler)
        {
            _createSessionCommandHandler = createSessionCommandHandler;
        }

        [HttpPost]
        [Route("api/authorize")]
        [AllowAnonymous]
        public string Authorize()
        {
            //TODO Add some authorization contract and some algorithm for contract validation

            var command = new CreateSessionCommand
            {
                Session = new Session
                {
                    Token = Guid.NewGuid(),
                    TokenExpired = DateTime.Now.AddMinutes(2)
                }
            };

            _createSessionCommandHandler.Execute(command);

            return command.Session.Token.ToString();
        }
    }
}
