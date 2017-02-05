using SimpleUber.DAL.Api.Repository;
using SimpleUber.DAL.Context;
using System;
using System.Linq;
using SimpleUber.DAL.Api.Entities;
using System.Collections.Generic;

namespace SimpleUber.DAL.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : EFEntity
    {
        protected SimpleUberContext _dbContext;

        public Repository()
        {
            _dbContext = new SimpleUberContext();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            var dbSet = _dbContext.Set<T>();
            return dbSet.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Save(T entity)
        {
            var dbSet = _dbContext.Set<T>();
            dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }
    }
}
