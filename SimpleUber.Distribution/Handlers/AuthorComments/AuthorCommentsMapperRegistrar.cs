using AutoMapper;
using SimpleUber.Distribution.Api.Services.AuthorComments.Entities;

namespace SimpleUber.Distribution.Handlers.AuthorComments
{
    public static class AuthorCommentsMapperRegistrar
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Services.Api.Services.AuthorComments.Entities.AuthorComment, AuthorComment>();
                cfg.CreateMap<AuthorComment, Services.Api.Services.AuthorComments.Entities.AuthorComment>();
            });

            return config.CreateMapper();
        }
    }
}
