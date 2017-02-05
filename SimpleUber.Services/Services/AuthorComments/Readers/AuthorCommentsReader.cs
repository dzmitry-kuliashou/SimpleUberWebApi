using System.Collections.Generic;
using SimpleUber.Services.Api.Services.AuthorComments.Entities;
using System.Linq;
using SimpleUber.DAL.Api.Repository;
using SimpleUber.Services.Services.AuthorComments.Mappers;

namespace SimpleUber.Services.Services.AuthorComments.Readers
{
    public class AuthorCommentsReader : IAuthorCommentsReader
    {
        private readonly ICommentsRepository _commentsRepository;

        public AuthorCommentsReader(
                ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public IEnumerable<AuthorComment> GetAuthorComments()
        {
            var comments = _commentsRepository.GetComments();

            return AuthorCommentMapperRegistrar.GetMapper()
                .Map<IEnumerable<DAL.Api.Entities.Comment>, IEnumerable<AuthorComment>>(comments);
        }
    }
}
