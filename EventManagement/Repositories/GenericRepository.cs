using EventManagement.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace EventManagement.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext context;
        private readonly DbSet<T> dbSet;
        private readonly ILogger<GenericRepository<T>> logger;

        public GenericRepository(AppDbContext context, ILogger<GenericRepository<T>> logger)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.dbSet = context.Set<T>();
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await dbSet.ToListAsync();
        public async Task<T?> GetByIdAsync(Guid id) => await dbSet.FindAsync(id);
        public async Task AddAsync(T entity)
        {
            try
            {
                await context.AddAsync(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error adding entity of type {EntityType}", typeof(T).Name);
                throw new Exception("An error occurred while adding the entity.", ex);
            }
        }
        public async Task UpdateAsync(T entity)
        {

            try
            {
                dbSet.Update(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error adding entity of type {EntityType}", typeof(T).Name);
                throw new Exception("An error occurred while Updating the entity.", ex);
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await dbSet.Where(predicate).ToListAsync();

    }
}
