using AutoMapper;
using SimpleUber.Services.Api.Services.AuthorComments.Entities;

namespace SimpleUber.Services.Services.AuthorComments.Mappers
{
    public static class AuthorCommentMapperRegistrar
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DAL.Api.Entities.Comment, AuthorComment>()
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author.Name))
                .ForMember(x => x.Comment, y => y.MapFrom(z => z.Text));
            });

            return config.CreateMapper();
        }
    }
}
