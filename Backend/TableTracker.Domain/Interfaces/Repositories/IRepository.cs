using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using TableTracker.Domain.Entities;

namespace TableTracker.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        Task<ICollection<TEntity>> GetAll(Expression filter = null, IQueryable include = null);

        Task<TEntity> FindById(TId id);

        Task Insert(TEntity entity);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}
