using SimpleUber.DAL.Api.Entities;
using SimpleUber.DAL.Api.Repository;
using System.Linq;

namespace SimpleUber.DAL.Repository
{
    public class SessionsRepository : Repository<Session>, ISessionsRepository
    {
        public Session GetSessionByToken(string token)
        {
            return _dbContext.Sessions.FirstOrDefault(x => x.Token.ToString() == token);
        }
    }
}
