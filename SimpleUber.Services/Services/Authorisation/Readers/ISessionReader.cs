
using SimpleUber.DAL.Api.Entities;

namespace SimpleUber.Services.Services.Authorisation.Readers
{
    public interface ISessionReader
    {
        Session GetSessionByToken(string token);
    }
}
