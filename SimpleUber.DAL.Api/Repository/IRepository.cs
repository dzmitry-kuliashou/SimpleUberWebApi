using SimpleUber.DAL.Api.Entities;
using System.Collections.Generic;

namespace SimpleUber.DAL.Api.Repository
{
    public interface IRepository<T> where T : EFEntity
    {
        void Save(T entity);

        T GetById(int id);

        void Update(T entity);

        void Delete(T entity);

        IEnumerable<T> GetAll();
    }
}
