using SimpleUber.Services.Api.Services.AuthorComments.Entities;
using System.Collections.Generic;

namespace SimpleUber.Services.Services.AuthorComments.Readers
{
    public interface IAuthorCommentsReader
    {
        IEnumerable<AuthorComment> GetAuthorComments();
    }
}
