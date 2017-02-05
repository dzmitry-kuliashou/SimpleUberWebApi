using SimpleUber.Services.Api.Services.AuthorComments.Entities;

namespace SimpleUber.Services.Services.AuthorComments.Writers
{
    public interface IAuthorCommentsWriter
    {
        int CreateAuthorComment(AuthorComment authorComment);
    }
}
