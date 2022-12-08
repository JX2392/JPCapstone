using System.Linq.Expressions;
using StudentManagerAPI.Models;

namespace StudentManagerAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        // T - Category
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        void Add(T item);

        Task CreateAsync(T entity);

        void Update(T item);

        void Remove(T item);

        Task RemoveAsync(T entity);

        void RemoveRange(IEnumerable<T> items);

        Task SaveAsync();
    }
}
