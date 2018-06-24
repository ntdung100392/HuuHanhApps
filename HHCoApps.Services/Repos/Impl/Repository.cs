using HHCoApps.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

namespace HHCoApps.Services.Repos.Impl
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> dbset;
        public Repository(DbContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }

        public T GetById(object id)
        {
            return dbset.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return dbset.AsQueryable();
        }

        public void Insert(T entity)
        {
            dbset.Add(entity);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }        
    }
}
