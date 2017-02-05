using SimpleUber.Services.Api.Common;
using SimpleUber.Services.Api.Services.AuthorComments.Entities;
using System.Collections.Generic;

namespace SimpleUber.Services.Api.Services.AuthorComments.QueryHandlers
{
    public interface IAuthorCommentsQueryHandler : IQueryHandler<IEnumerable<AuthorComment>>
    {
    }
}