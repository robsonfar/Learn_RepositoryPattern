﻿using System.Linq.Expressions;

namespace Learn_RepositoryPattern.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(Expression<Func<T, bool>> filter);

        void Add(T entity);
        
        //void Update(T entity);
        
        void Remove(T entity);
    }
}
