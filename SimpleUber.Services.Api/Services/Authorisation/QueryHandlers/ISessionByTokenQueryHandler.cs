using SimpleUber.Services.Api.Common;
using SimpleUber.Services.Api.Services.Authorisation.Entities;

namespace SimpleUber.Services.Api.Services.Authorisation.QueryHandlers
{
    public interface ISessionByTokenQueryHandler : IQueryHandler<string, Session>
    {
    }
}
