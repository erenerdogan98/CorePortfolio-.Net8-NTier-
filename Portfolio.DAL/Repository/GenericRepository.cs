using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Portfolio.DAL.Abstract;
using Portfolio.DAL.Context;
using Portfolio.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace Portfolio.DAL.Repository
{
    public class GenericRepository<T>(AppDbContext context) : IGenericDAL<T> where T : class, IEntityBase, new()
    {
        internal DbSet<T> dbSet = context.Set<T>();
        private async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        private IQueryable<T> QueryWithIncludes(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet;
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            //context.Entry(entity).State = EntityState.Detached;
            context.Remove(entity);
            context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await QueryWithIncludes().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter) => await QueryWithIncludes().Where(filter).ToListAsync();


        public async Task<T> GetByIdAsync(int id) => await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public void Update(T entity)
        {
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            context.SaveChanges();
        }

        public T GetById(int id) => dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
    }
}
