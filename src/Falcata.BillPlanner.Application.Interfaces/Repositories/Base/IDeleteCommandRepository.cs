using Falcata.BillPlanner.Domain.Models.Base;

namespace Falcata.BillPlanner.Application.Interfaces.Repositories.Base;

public interface IDeleteCommandRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
}