using SimpleUber.DAL.Api.Entities;

namespace SimpleUber.DAL.Api.Repository
{
    public interface IAuthorsRepository : IRepository<Author>
    {
        Author GetAuthorByName(string authorName);
    }
}
