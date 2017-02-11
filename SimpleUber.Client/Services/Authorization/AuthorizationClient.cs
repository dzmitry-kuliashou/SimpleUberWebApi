using SimpleUber.Client.Services.BaseApiClient;
using SimpleUber.Distribution.Api.Services.Authorization;

namespace SimpleUber.Client.Services.Authorization
{
    public class AuthorizationClient : BaseApiClient<IAuthorization>, IAuthorization
    {
        public string Authorize()
        {
            return SendPost<string>(null);
        }
    }
}
