using System.Linq.Expressions;

namespace TravelGuide.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> caretiria = null, string[] Includes = null);
        Task<T> GetById(int id);
        Task<T> AddItem(T item);
        Task<T> UpdateItem(T item);
        Task DeleteItem(int id);
    }
}
