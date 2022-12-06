using StudentManager.Models;
using System.Linq.Expressions;

namespace StudentManager.Repository
{
    public interface IRepository<T> where T : class
    {
        // T - Category
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

        IEnumerable<T> GetAll();

        void Add(T item);

        void Update(T item);

        void Remove(T item);

        void RemoveRange(IEnumerable<T> items);
    }
}
