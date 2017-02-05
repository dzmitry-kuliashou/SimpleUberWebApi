using SimpleUber.DAL.Api.Repository;

namespace SimpleUber.Services.Services.ServiceLog.Writers
{
    public class ServiceLogWriter : IServiceLogWriter
    {
        private readonly IServiceLogsRepository _serviceLogsRepository;

        public ServiceLogWriter(
            IServiceLogsRepository serviceLogsRepository)
        {
            _serviceLogsRepository = serviceLogsRepository;
        }

        public void CreateServiceLog(DAL.Api.Entities.ServiceLog serviceLog)
        {
            _serviceLogsRepository.Save(serviceLog);
        }
    }
}
