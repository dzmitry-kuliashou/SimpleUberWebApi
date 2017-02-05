using SimpleUber.DAL.Api.Entities;
using SimpleUber.DAL.Api.Repository;

namespace SimpleUber.Services.Services.Authorisation.Readers
{
    public class SessionReader : ISessionReader
    {
        private readonly ISessionsRepository _sessionsRepository;

        public SessionReader(
            ISessionsRepository sessionsRepository)
        {
            _sessionsRepository = sessionsRepository;
        }

        public Session GetSessionByToken(string token)
        {
            return _sessionsRepository.GetSessionByToken(token);
        }
    }
}
