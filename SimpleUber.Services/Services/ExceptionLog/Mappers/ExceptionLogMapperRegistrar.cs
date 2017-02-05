using AutoMapper;
using SimpleUber.Services.Api.Services.ExceptionLog.CommandHandlers.Commands;

namespace SimpleUber.Services.Services.ExceptionLog.Mappers
{
    public static class ExceptionLogMapperRegistrar
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateExceptionLogCommand, SimpleUber.DAL.Api.Entities.ExceptionLog>();
            });

            return config.CreateMapper();
        }
    }
}
