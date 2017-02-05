using SimpleUber.Services.Api.Services.AuthorComments.QueryHandlers;
using SimpleUber.Services.Api.Services.AuthorComments.Entities;
using System.Collections.Generic;
using SimpleUber.Services.Services.AuthorComments.Readers;

namespace SimpleUber.Services.Services.AuthorComments.QueryHandlers
{
    public class AuthorCommentsQueryHandler : IAuthorCommentsQueryHandler
    {
        private readonly IAuthorCommentsReader _authorCommentsReader;

        public AuthorCommentsQueryHandler(
            IAuthorCommentsReader authorCommentsReader)
        {
            _authorCommentsReader = authorCommentsReader;
        }

        public IEnumerable<AuthorComment> Execute()
        {
            return _authorCommentsReader.GetAuthorComments();
        }
    }
}