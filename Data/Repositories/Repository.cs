using Domain.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected IDbContext _dbContext;
        private DbSet<T> _dbSet;

        public Repository(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(object Id)
        {
            return _dbSet.Find(Id);
        }

        public virtual T Insert(T obj)
        {
            var result = _dbSet.Add(obj);
            return result;
        }

        public void Update(T obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object Id)
        {
            T getObjById = _dbSet.Find(Id);
            _dbSet.Remove(getObjById);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
