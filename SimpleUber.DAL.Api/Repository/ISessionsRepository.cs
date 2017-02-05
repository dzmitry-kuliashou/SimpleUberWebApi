using SimpleUber.DAL.Api.Entities;

namespace SimpleUber.DAL.Api.Repository
{
    public interface ISessionsRepository : IRepository<Session>
    {
        Session GetSessionByToken(string token);
    }
}
