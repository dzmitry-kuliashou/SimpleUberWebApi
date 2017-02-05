using SimpleUber.Services.Api.Services.Authorisation.QueryHandlers;
using SimpleUber.Services.Api.Services.Authorisation.Entities;
using SimpleUber.Services.Services.Authorisation.Readers;
using SimpleUber.Services.Services.Authorisation.Mappers;

namespace SimpleUber.Services.Services.Authorisation.QueryHandlers
{
    public class SessionByTokenQueryHandler : ISessionByTokenQueryHandler
    {
        private readonly ISessionReader _sessionReader;

        public SessionByTokenQueryHandler(
            ISessionReader sessionReader)
        {
            _sessionReader = sessionReader;
        }

        public Session Execute(string token)
        {
            var sessionDto = _sessionReader.GetSessionByToken(token);

            return SessionMapperRegistrar.GetMapper()
                .Map<DAL.Api.Entities.Session, Session>(sessionDto);
        }
    }
}
