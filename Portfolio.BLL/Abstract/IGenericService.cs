using System.Linq.Expressions;

namespace Portfolio.BLL.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TAddAsync(T entity);
        Task TDeleteAsync(T entity);
        void TUpdate(T entity);
        Task<IEnumerable<T>> TGetAllAsync();
        Task<T> TGetByIdAsync(int id);
        T TGetById(int id);
        Task<IEnumerable<T>> TGetAllAsync(Expression<Func<T, bool>> filter);
    }
}
