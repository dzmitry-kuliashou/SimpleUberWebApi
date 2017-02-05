using SimpleUber.Services.Api.Common;
using SimpleUber.Services.Api.Services.AuthorComments.CommandHandlers.Commands;

namespace SimpleUber.Services.Api.Services.AuthorComments.CommandHandlers
{
    public interface ICreateAuthorCommentCommandHandler : ICommandHandler<CreateAuthorCommentCommand, int>
    {
    }
}
