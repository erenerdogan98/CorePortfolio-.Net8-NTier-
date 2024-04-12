using Portfolio.Entities;
using System.Linq.Expressions;

namespace Portfolio.DAL.Abstract
{
    public interface IGenericDAL<T> where T : class, IEntityBase , new() 
    {
        Task AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);
    }
}
