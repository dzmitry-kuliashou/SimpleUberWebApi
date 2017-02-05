using SimpleUber.Distribution.Api.Services.AuthorComments;
using System.Collections.Generic;
using SimpleUber.Distribution.Api.Services.AuthorComments.Entities;
using System.Web.Http;
using SimpleUber.Services.Api.Services.AuthorComments.QueryHandlers;
using SimpleUber.Services.Api.Services.AuthorComments.CommandHandlers;
using SimpleUber.Services.Api.Services.AuthorComments.CommandHandlers.Commands;

namespace SimpleUber.Distribution.Handlers.AuthorComments
{
    public class AuthorCommentsHandler : ApiController, IAuthorComments
    {
        private readonly IAuthorCommentsQueryHandler _authorCommentsQueryHandler;
        private readonly ICreateAuthorCommentCommandHandler _createAuthorCommentCommandHandler;

        public AuthorCommentsHandler(
            IAuthorCommentsQueryHandler authorCommentsQueryHandler,
            ICreateAuthorCommentCommandHandler createAuthorCommentCommandHandler)
        {
            _authorCommentsQueryHandler = authorCommentsQueryHandler;
            _createAuthorCommentCommandHandler = createAuthorCommentCommandHandler;
        }

        [HttpPost]
        [Route("api/authorcomments/new")]
        [AllowAnonymous]
        public int CreateNewComment(AuthorComment comment)
        {
            var createAuthorCommentCommand = new CreateAuthorCommentCommand
            {
                AuthorComment = AuthorCommentsMapperRegistrar.GetMapper()
                                    .Map<AuthorComment, Services.Api.Services.AuthorComments.Entities.AuthorComment>(comment)
            };

            return _createAuthorCommentCommandHandler.Execute(createAuthorCommentCommand);
        }

        [HttpGet]
        [Route("api/authorcomments")]
        [AllowAnonymous]
        public IEnumerable<AuthorComment> GetAuthorComments()
        {
            var authorComments = _authorCommentsQueryHandler.Execute();

            return AuthorCommentsMapperRegistrar.GetMapper()
                .Map<IEnumerable<Services.Api.Services.AuthorComments.Entities.AuthorComment>, IEnumerable<AuthorComment>>(authorComments);
        }
    }
}
