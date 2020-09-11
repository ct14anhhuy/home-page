using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Repositories.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        TEntity Add(TEntity entity);

        TEntity DeleteById(object id);

        TEntity Delete(TEntity entity);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetMultiByPredicate(Expression<Func<TEntity, bool>> condition);

        IEnumerable<TEntity> GetMultiByPredicate(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includes);

        TEntity GetSingleById(object id);

        TEntity GetSingleByPredicate(Expression<Func<TEntity, bool>> condition);

        TEntity GetSingleByPredicate(Expression<Func<TEntity, bool>> condition, params Expression<Func<TEntity, object>>[] includes);

        void Update(TEntity entity);
    }
}