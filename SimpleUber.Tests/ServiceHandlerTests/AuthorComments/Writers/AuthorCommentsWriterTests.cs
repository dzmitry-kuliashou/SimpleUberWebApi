using Moq;
using NUnit.Framework;
using SimpleUber.DAL.Api.Entities;
using SimpleUber.DAL.Api.Repository;
using SimpleUber.Services.Api.Services.AuthorComments.Entities;
using SimpleUber.Services.Services.AuthorComments.Writers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleUber.Tests.ServiceHandlerTests.AuthorComments.Writers
{
    [TestFixture]
    public class AuthorCommentsWriterTests
    {
        private AuthorCommentsWriter authorCommentsWriter;

        private List<Author> authors;
        private List<Comment> comments;

        [SetUp]
        public void SetUpTest()
        {
            comments = new List<Comment>();
            authors = new List<Author>();

            var mockCommentsRepository = new Mock<ICommentsRepository>();
            Action<Comment> addCommentFunction = i => comments.Add(i);
            mockCommentsRepository
                .Setup(x => x.Save(It.IsAny<Comment>()))
                .Callback<Comment>((comment) => addCommentFunction(comment));

            var mockAuthorsRepository = new Mock<IAuthorsRepository>();
            Func<string, Author> getAuthorByNameFunction = i => authors.FirstOrDefault(x => x.Name == i);
            mockAuthorsRepository
                .Setup(x => x.GetAuthorByName(It.IsAny<string>()))
                .Returns<string>((authorName) => getAuthorByNameFunction(authorName));

            authorCommentsWriter = new AuthorCommentsWriter(mockCommentsRepository.Object, mockAuthorsRepository.Object);
        }

        [Test]
        public void WhenAuthorFromAuthorCommentAlreadyExists_NotAddNewAuthor()
        {
            authors.Add(new Author { Id = 5, Name = "Author1" });

            var authorComment = new AuthorComment { Author = "Author1", Comment = "Comment1" };

            authorCommentsWriter.CreateAuthorComment(authorComment);

            Assert.AreEqual(5, comments.First().AuthorId);
        }

        [Test]
        public void WhenAuthorFromAuthorCommentDoesNotExist_AddNewAuthor()
        {
            authors.Add(new Author { Id = 5, Name = "Author1" });

            var authorComment = new AuthorComment { Author = "Author2", Comment = "Comment1" };

            authorCommentsWriter.CreateAuthorComment(authorComment);

            Assert.AreEqual(0, comments.First().AuthorId);
        }

        [Test]
        public void WhenTwoAuthorCommentsWithSameCommentAdded_AddBothComments()
        {
            var authorComment1 = new AuthorComment { Author = "Author1", Comment = "Comment1" };
            var authorComment2 = new AuthorComment { Author = "Author2", Comment = "Comment1" };

            authorCommentsWriter.CreateAuthorComment(authorComment1);
            authorCommentsWriter.CreateAuthorComment(authorComment2);

            Assert.AreEqual(2, comments.Count);
        }
    }
}
