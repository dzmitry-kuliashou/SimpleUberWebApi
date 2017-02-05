using SimpleUber.DAL.Api.Entities;
using SimpleUber.DAL.Api.Repository;
using System.Linq;

namespace SimpleUber.DAL.Repository
{
    public class AuthorsRepository : Repository<Author>, IAuthorsRepository
    {
        public Author GetAuthorByName(string authorName)
        {
            return _dbContext.Authors.Where(x => x.Name == authorName).FirstOrDefault();
        }
    }
}
