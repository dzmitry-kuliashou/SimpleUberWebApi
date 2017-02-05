using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SimpleUber.DAL.Api.Entities;
using SimpleUber.DAL.Api.Repository;

namespace SimpleUber.DAL.Repository
{
    public class CommentsRepository : Repository<Comment>, ICommentsRepository
    {
        public IEnumerable<Comment> GetComments()
        {
            return _dbContext.Comments.Include(c => c.Author).ToList();
        }
    }
}
