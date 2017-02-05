namespace SimpleUber.Services.Services.ServiceLog.Writers
{
    public interface IServiceLogWriter
    {
        void CreateServiceLog(SimpleUber.DAL.Api.Entities.ServiceLog serviceLog);
    }
}
