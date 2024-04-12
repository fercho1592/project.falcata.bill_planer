using Falcata.BillPlanner.Application.Interfaces.QueryBuilders.Base;
using Falcata.BillPlanner.Domain.Models.Base;

namespace Falcata.BillPlanner.Application.Interfaces.Repositories.Base;

public interface IQueryRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    Task<List<TEntity>> ListAsync(IQueryBuilder<TEntity> queryBuilder, CancellationToken cancellationToken);
    Task<TEntity?> FindAsync(IQueryBuilder<TEntity> queryBuilder, CancellationToken cancellationToken);
}