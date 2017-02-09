using SimpleUber.Distribution.Api.Common;

namespace SimpleUber.Distribution.Api.Services.Authorization
{
    public interface IAuthorization
    {
        [RouteUri("api/authorize", HttpMethod.Post)]
        string Authorize();
    }
}
