using SimpleUber.Distribution.Api.Common;
using SimpleUber.Distribution.Api.Services.AuthorComments.Entities;
using System.Collections.Generic;

namespace SimpleUber.Distribution.Api.Services.AuthorComments
{
    public interface IAuthorComments
    {
        [RouteUri("api/authorcomments", HttpMethod.Get)]
        IEnumerable<AuthorComment> GetAuthorComments();

        [RouteUri("api/authorcomments/new", HttpMethod.Post)]
        int CreateNewComment(AuthorComment comment);
    }
}