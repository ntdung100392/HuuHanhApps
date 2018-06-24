using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace HHCoApps.Services.Repos
{
    public interface IRepository<T>
    {
        T GetById(object id);

        IQueryable<T> GetAll();

        void Update(T entity);

        void Insert(T entity);

        void Delete(T entity);
    }
}
