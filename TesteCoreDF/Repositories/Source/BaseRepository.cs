using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TesteCoreDF.Models;
using TesteCoreDF.Repositories.Interfaces;

namespace TesteCoreDF.Repositories.Source
{
    class BaseRepository<TEntity>
        where TEntity: class, IEntity
    {
        protected readonly AcademicoContext bd;
        protected readonly DbSet<TEntity> Entity;

        public BaseRepository(AcademicoContext _bd)
        {
            bd = _bd;
            Entity = bd.Set<TEntity>();
        }

        public virtual async Task<Tuple<IEnumerable<TEntity>, int>> Obter(int skip, int take, bool asNoTracking = true)
        {
            var databaseCount = await Entity.CountAsync().ConfigureAwait(false);
            if (asNoTracking)
                return new Tuple<IEnumerable<TEntity>, int>
                (
                    await Entity.AsNoTracking().Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                    databaseCount
                );

            return new Tuple<IEnumerable<TEntity>, int>
            (
                await Entity.Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                databaseCount
            );
        }

        public virtual async Task<Tuple<IEnumerable<TEntity>, int>> Obter(int skip, int take, Expression<Func<TEntity, bool>> where, bool asNoTracking = true)
        {
            var databaseCount = await Entity.CountAsync().ConfigureAwait(false);
            if (asNoTracking)
                return new Tuple<IEnumerable<TEntity>, int>
                (
                    await Entity.AsNoTracking().Where(where).Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                    databaseCount
                );

            return new Tuple<IEnumerable<TEntity>, int>
            (
                await Entity.Where(where).Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                databaseCount
            );
        }

        public virtual async Task<Tuple<IEnumerable<TEntity>, int>> Obter(int skip, int take, Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, object>> orderBy, bool asNoTracking = true)
        {
            var databaseCount = await Entity.CountAsync().ConfigureAwait(false);
            if (asNoTracking)
                return new Tuple<IEnumerable<TEntity>, int>
                (
                    await Entity.AsNoTracking().OrderBy(orderBy).Where(where).Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                    databaseCount
                );

            return new Tuple<IEnumerable<TEntity>, int>
            (
                await Entity.OrderBy(orderBy).Where(where).Skip(skip).Take(take).ToListAsync().ConfigureAwait(false),
                databaseCount
            );
        }


        public virtual async Task<TEntity> GetByIdAsync(int entityId, bool asNoTracking = true)
        {
            return asNoTracking
                ? await Entity.AsNoTracking().SingleOrDefaultAsync(entity => entity.Id == entityId).ConfigureAwait(false)
                : await Entity.FindAsync(entityId).ConfigureAwait(false);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await Entity.AddAsync(entity).ConfigureAwait(false);
        }

        public virtual async Task AddCollectionAsync(IEnumerable<TEntity> entities)
        {
            await Entity.AddRangeAsync(entities).ConfigureAwait(false);
        }

        public virtual IEnumerable<TEntity> AddCollectionWithProxy(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Entity.Add(entity);
                yield return entity;
            }
        }


        public virtual Task UpdateAsync(TEntity entity)
        {
            Entity.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateCollectionAsync(IEnumerable<TEntity> entities)
        {
            Entity.UpdateRange(entities);
            return Task.CompletedTask;
        }


        public virtual Task RemoveByAsync(Func<TEntity, bool> where)
        {
            Entity.RemoveRange(Entity.ToList().Where(where));
            return Task.CompletedTask;
        }

        public virtual Task RemoveAsync(TEntity entity)
        {
            Entity.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual async Task SaveChangesAsync()
        {
            await bd.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
