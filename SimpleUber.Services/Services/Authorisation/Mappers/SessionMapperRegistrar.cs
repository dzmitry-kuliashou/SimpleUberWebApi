using AutoMapper;
using SimpleUber.DAL.Api.Entities;

namespace SimpleUber.Services.Services.Authorisation.Mappers
{
    public static class SessionMapperRegistrar
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SimpleUber.Services.Api.Services.Authorisation.Entities.Session, Session>();
                cfg.CreateMap<Session, SimpleUber.Services.Api.Services.Authorisation.Entities.Session>();
            });

            return config.CreateMapper();
        }
    }
}
