using SimpleUber.Services.Api.Services.Authorisation.CommandHandlers;
using SimpleUber.Services.Api.Services.Authorisation.CommandHandlers.Commands;
using SimpleUber.Services.Services.Authorisation.Writers;
using SimpleUber.DAL.Api.Entities;
using SimpleUber.Services.Services.Authorisation.Mappers;

namespace SimpleUber.Services.Services.Authorisation.CommandHandlers
{
    public class CreateSessionCommandHandler : ICreateSessionCommandHandler
    {
        private readonly ISessionWriter _sessionWriter;

        public CreateSessionCommandHandler(
            ISessionWriter sessionWriter)
        {
            _sessionWriter = sessionWriter;
        }

        public void Execute(CreateSessionCommand command)
        {
            var sessionDto = SessionMapperRegistrar.GetMapper()
                .Map<SimpleUber.Services.Api.Services.Authorisation.Entities.Session, Session>(command.Session);

            _sessionWriter.CreateSession(sessionDto);
        }
    }
}
