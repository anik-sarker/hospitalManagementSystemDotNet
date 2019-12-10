 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HMS.Models;
using HMS.Interface;

namespace HMS.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context ;
        public Repository(ApplicationDbContext context)
        {
            Context = context;
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public void Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void Complete()
        {
            Context.SaveChanges();
        }
    }
}