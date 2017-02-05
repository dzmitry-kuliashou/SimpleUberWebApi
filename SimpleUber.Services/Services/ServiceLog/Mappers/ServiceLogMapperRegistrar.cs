using AutoMapper;
using SimpleUber.Services.Api.Services.ServiceLog.CommandHandlers.Commands;

namespace SimpleUber.Services.Services.ServiceLog.Mappers
{
    public static class ServiceLogMapperRegistrar
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateServiceLogCommand, SimpleUber.DAL.Api.Entities.ServiceLog>();
            });

            return config.CreateMapper();
        }
    }
}
