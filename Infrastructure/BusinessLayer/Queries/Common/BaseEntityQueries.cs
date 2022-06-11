using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PreciousGames.Verot.Morin.BusinessLayer.Exceptions;
using PreciousGames.Verot.Morin.ModelLayer.Contexts;
using PreciousGames.Verot.Morin.ModelLayer.Entities.Common;

namespace PreciousGames.Verot.Morin.BusinessLayer.Queries.Common
{
    internal abstract class BaseEntityQueries<TEntity> where TEntity : BaseEntity
    {
        private readonly PreciousGameContext _dbContext;
        protected PreciousGameContext DbContext => _dbContext;

        private readonly DbSet<TEntity> _dbSet;
        protected DbSet<TEntity> DbSet => _dbSet;

        public BaseEntityQueries(PreciousGameContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual List<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.FirstOrDefault(entity => entity.Id == id);
        }

        public int Count()
        {
            return _dbSet.Count();
        }

        public TEntity Add(TEntity newEntity)
        {
            return _dbSet.Add(newEntity);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity existingEntity = GetById(entity.Id);

            if (existingEntity == null)
                throw new EntityNotFoundException(entity.Id);

            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public void Delete(int id)
        {
            TEntity existingEntity = GetById(id);

            if (existingEntity == null)
                throw new EntityNotFoundException(id);

            if (_dbContext.Entry(existingEntity).State == EntityState.Detached)
                _dbSet.Attach(existingEntity);

            _dbSet.Remove(existingEntity);
        }
    }
}