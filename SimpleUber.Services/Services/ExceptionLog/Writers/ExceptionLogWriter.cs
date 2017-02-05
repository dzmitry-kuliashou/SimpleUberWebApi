using SimpleUber.DAL.Api.Repository;

namespace SimpleUber.Services.Services.ExceptionLog.Writers
{
    public class ExceptionLogWriter : IExceptionLogWriter
    {
        private readonly IExceptionLogsRepository _repository;

        public ExceptionLogWriter(
            IExceptionLogsRepository repository)
        {
            _repository = repository;
        }

        public void CreateExceptionLog(DAL.Api.Entities.ExceptionLog exceptionLog)
        {
            _repository.Save(exceptionLog);
        }
    }
}
