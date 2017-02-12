using FluentValidation.Results;
using NUnit.Framework;
using SimpleUber.Errors.ErrorCodes;
using SimpleUber.Services.Api.Services.AuthorComments.CommandHandlers.Commands;
using SimpleUber.Services.Api.Services.AuthorComments.Entities;
using SimpleUber.Services.Services.AuthorComments.Validators;

namespace SimpleUber.Tests.ServiceHandlerTests.AuthorComments.Validators
{
    [TestFixture]
    class CreateAuthorCommentCommandValidator_AuthorIsNotPopulated
    {
        private ValidationResult validationResult;

        [SetUp]
        public void SetUpTest()
        {
            var createAuthorCommentCommandValidator = new CreateAuthorCommentCommandValidator();

            var authorComment = new AuthorComment { Author = string.Empty, Comment = "Comment1" };
            CreateAuthorCommentCommand createAuthorCommentCommand = new CreateAuthorCommentCommand { AuthorComment = authorComment };

            validationResult = createAuthorCommentCommandValidator.Validate(createAuthorCommentCommand);
        }

        [Test]
        public void ValidationResultMustNotBeValid()
        {
            Assert.AreEqual(false, validationResult.IsValid);
        }

        [Test]
        public void ValidationResultMustHaveOneError()
        {
            Assert.AreEqual(1, validationResult.Errors.Count);
        }

        [Test]
        public void MustReturnCorrectValidationError()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(ErrorCodes.RequiredParameterAuthor.Code.ToString(), validationResult.Errors[0].ErrorCode);
                Assert.AreEqual(ErrorCodes.RequiredParameterAuthor.Message, validationResult.Errors[0].ErrorMessage);
            });
        }
    }
}
