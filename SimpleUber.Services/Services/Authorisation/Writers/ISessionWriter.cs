using SimpleUber.DAL.Api.Entities;

namespace SimpleUber.Services.Services.Authorisation.Writers
{
    public interface ISessionWriter
    {
        void CreateSession(Session session);
    }
}
