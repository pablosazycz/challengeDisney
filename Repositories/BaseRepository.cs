using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Disney.Repositories
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _dbContext;
        private DbSet<TEntity> _dbset;

        protected BaseRepository(TContext dbContext)
        {
            _dbContext = dbContext;
        }
        protected DbSet<TEntity> DbSet
        {
            get
            {
                return _dbset ??= _dbContext.Set<TEntity>();
            }
        }

        public List<TEntity> GetAllEntities()
        {
            return DbSet.ToList();
        }

        public TEntity GetEntities(int Id)
        {
            return DbSet.Find(Id);
        }

        public TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
             DbSet.Remove(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            DbSet.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

    }
}
