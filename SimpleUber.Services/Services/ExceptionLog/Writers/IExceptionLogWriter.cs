namespace SimpleUber.Services.Services.ExceptionLog.Writers
{
    public interface IExceptionLogWriter
    {
        void CreateExceptionLog(SimpleUber.DAL.Api.Entities.ExceptionLog exceptionLog);
    }
}
