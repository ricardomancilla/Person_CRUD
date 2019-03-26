using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(object Id);

        T Insert(T entity);

        void Update(T entity);

        void Delete(object Id);

        void SaveChanges();
    }
}
