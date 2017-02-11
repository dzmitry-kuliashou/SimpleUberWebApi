using SimpleUber.Client.Services.BaseApiClient;
using SimpleUber.Distribution.Api.Services.AuthorComments;
using SimpleUber.Distribution.Api.Services.AuthorComments.Entities;
using System.Collections.Generic;

namespace SimpleUber.Client.Services.AuthorComments
{
    public class AuthorCommentsClient : BaseApiClient<IAuthorComments>, IAuthorComments
    {
        public IEnumerable<AuthorComment> GetAuthorComments()
        {
            return SendGet<IEnumerable<AuthorComment>>();
        }

        public int CreateNewComment(AuthorComment comment)
        {
            return SendPost<int>(comment);
        }
    }
}
