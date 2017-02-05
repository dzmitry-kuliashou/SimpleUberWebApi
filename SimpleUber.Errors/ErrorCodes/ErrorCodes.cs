
namespace SimpleUber.Errors.ErrorCodes
{
    public static class ErrorCodes
    {
        public static readonly ErrorCode RequiredParameterAuthorComment = new ErrorCode(1000000, "AuthorComment is required parameter");
        public static readonly ErrorCode RequiredParameterAuthor = new ErrorCode(1000001, "Author is required parameter");
        public static readonly ErrorCode RequiredParameterComment = new ErrorCode(1000002, "Comment is required parameter");
    }
}
