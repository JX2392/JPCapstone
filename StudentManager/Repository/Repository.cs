using Microsoft.EntityFrameworkCore;
using StudentManager.Data;
using StudentManager.Models;
using StudentManager.Repository.IRepository;
using System.Linq.Expressions;

namespace StudentManager.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        void IRepository<T>.Add(T item)
        {
            dbSet.Add(item);
        }
        void IRepository<T>.Update(T item)
        {
            dbSet.Update(item);
        }
        IEnumerable<T> IRepository<T>.GetAll()
        {
            IQueryable<T> query = dbSet;
            return query.ToList();
        }

        T IRepository<T>.GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;

            query = query.Where(filter);

            return query.FirstOrDefault();
        }

        void IRepository<T>.Remove(T item)
        {
            dbSet.Remove(item);
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            dbSet.RemoveRange(items);
        }
    }
}
