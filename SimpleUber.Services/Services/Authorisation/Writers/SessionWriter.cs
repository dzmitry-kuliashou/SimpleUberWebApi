using SimpleUber.DAL.Api.Entities;
using SimpleUber.DAL.Api.Repository;

namespace SimpleUber.Services.Services.Authorisation.Writers
{
    public class SessionWriter : ISessionWriter
    {
        private readonly ISessionsRepository _sessionsRepository;

        public SessionWriter(
            ISessionsRepository sessionsRepository)
        {
            _sessionsRepository = sessionsRepository;
        }

        public void CreateSession(Session session)
        {
            _sessionsRepository.Save(session);
        }
    }
}
