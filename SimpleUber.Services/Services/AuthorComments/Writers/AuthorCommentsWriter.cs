using SimpleUber.Services.Api.Services.AuthorComments.Entities;
using SimpleUber.DAL.Api.Repository;
using SimpleUber.DAL.Api.Entities;

namespace SimpleUber.Services.Services.AuthorComments.Writers
{
    public class AuthorCommentsWriter : IAuthorCommentsWriter
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorCommentsWriter(
            ICommentsRepository commentsRepository,
            IAuthorsRepository authorsRepository)
        {
            _commentsRepository = commentsRepository;
            _authorsRepository = authorsRepository;
        }

        public int CreateAuthorComment(AuthorComment authorComment)
        {
            var author = _authorsRepository.GetAuthorByName(authorComment.Author);

            Comment comment = null;

            if(author == null)
            {
                author = new Author()
                            {
                                Name = authorComment.Author
                            };

                comment = new Comment()
                            {
                                Text = authorComment.Comment,
                                Author = author
                            };
            }
            else
            {
                comment = new Comment()
                            {
                                Text = authorComment.Comment,
                                AuthorId = author.Id
                            };
            }

            _commentsRepository.Save(comment);

            return comment.Id;
        }
    }
}
