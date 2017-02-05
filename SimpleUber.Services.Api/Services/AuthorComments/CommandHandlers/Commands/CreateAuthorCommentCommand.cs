using SimpleUber.Services.Api.Services.AuthorComments.Entities;

namespace SimpleUber.Services.Api.Services.AuthorComments.CommandHandlers.Commands
{
    public class CreateAuthorCommentCommand
    {
        public AuthorComment AuthorComment { get; set; }
    }
}
