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
        protected readonly PreciousGameContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public BaseEntityQueries(PreciousGameContext context)
        {
            DbContext = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.FirstOrDefault(entity => entity.Id == id);
        }

        public TEntity Add(TEntity newEntity)
        {
            return DbSet.Add(newEntity);
        }

        public TEntity Update(TEntity entity)
        {
            TEntity existingEntity = GetById(entity.Id);

            if (existingEntity == null)
                throw new EntityNotFoundException(entity.Id);

            DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }

        public void Delete(int id)
        {
            TEntity existingEntity = GetById(id);

            if (existingEntity == null)
                throw new EntityNotFoundException(id);

            if (DbContext.Entry(existingEntity).State == EntityState.Detached)
                DbSet.Attach(existingEntity);

            DbSet.Remove(existingEntity);
        }
    }
}