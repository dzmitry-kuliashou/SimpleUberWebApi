using FluentValidation;
using SimpleUber.Errors.ErrorCodes;
using SimpleUber.Services.Api.Services.AuthorComments.CommandHandlers.Commands;

namespace SimpleUber.Services.Services.AuthorComments.Validators
{
    public class CreateAuthorCommentCommandValidator : AbstractValidator<CreateAuthorCommentCommand>
    {
        public CreateAuthorCommentCommandValidator()
        {
            RuleFor(x => x.AuthorComment)
                .NotNull()
                .WithErrorCode(ErrorCodes.RequiredParameterAuthorComment.Code.ToString())
                .WithMessage(ErrorCodes.RequiredParameterAuthorComment.Message);

            RuleFor(x => x.AuthorComment.Author)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithErrorCode(ErrorCodes.RequiredParameterAuthor.Code.ToString())
                .WithMessage(ErrorCodes.RequiredParameterAuthor.Message)
                .When(x => x.AuthorComment != null);

            RuleFor(x => x.AuthorComment.Comment)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithErrorCode(ErrorCodes.RequiredParameterComment.Code.ToString())
                .WithMessage(ErrorCodes.RequiredParameterComment.Message)
                .When(x => x.AuthorComment != null);
        }
    }
}
