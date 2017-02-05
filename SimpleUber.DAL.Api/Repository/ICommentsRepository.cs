using SimpleUber.DAL.Api.Entities;
using System.Collections.Generic;

namespace SimpleUber.DAL.Api.Repository
{
    public interface ICommentsRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetComments();
    }
}
