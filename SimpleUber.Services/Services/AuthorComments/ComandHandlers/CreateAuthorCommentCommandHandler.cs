using SimpleUber.Services.Api.Services.AuthorComments.CommandHandlers;
using SimpleUber.Services.Api.Services.AuthorComments.CommandHandlers.Commands;
using SimpleUber.Services.Attributes;
using SimpleUber.Services.Services.AuthorComments.Writers;

namespace SimpleUber.Services.Services.AuthorComments.ComandHandlers
{
    [ValidationRequired]
    public class CreateAuthorCommentCommandHandler : ICreateAuthorCommentCommandHandler
    {
        private readonly IAuthorCommentsWriter _authorCommentWriter;

        public CreateAuthorCommentCommandHandler(
            IAuthorCommentsWriter authorCommentWriter)
        {
            _authorCommentWriter = authorCommentWriter;
        }

        public int Execute(CreateAuthorCommentCommand comment)
        {
            return _authorCommentWriter.CreateAuthorComment(comment.AuthorComment);
        }
    }
}
