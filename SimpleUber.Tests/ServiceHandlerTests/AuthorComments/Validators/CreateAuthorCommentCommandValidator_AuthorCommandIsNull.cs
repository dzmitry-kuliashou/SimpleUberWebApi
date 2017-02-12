using FluentValidation.Results;
using NUnit.Framework;
using SimpleUber.Errors.ErrorCodes;
using SimpleUber.Services.Api.Services.AuthorComments.CommandHandlers.Commands;
using SimpleUber.Services.Services.AuthorComments.Validators;

namespace SimpleUber.Tests.ServiceHandlerTests.AuthorComments.Validators
{
    [TestFixture]
    public class CreateAuthorCommentCommandValidator_AuthorCommandIsNull
    {
        private ValidationResult validationResult;

        [SetUp]
        public void SetUpTest()
        {
            var createAuthorCommentCommandValidator = new CreateAuthorCommentCommandValidator();
            CreateAuthorCommentCommand createAuthorCommentCommand = new CreateAuthorCommentCommand { AuthorComment = null };

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
                Assert.AreEqual(ErrorCodes.RequiredParameterAuthorComment.Code.ToString(), validationResult.Errors[0].ErrorCode);
                Assert.AreEqual(ErrorCodes.RequiredParameterAuthorComment.Message, validationResult.Errors[0].ErrorMessage);
            });
        }
    }
}
