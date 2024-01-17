using Falcata.BillPlanner.Domain.Models.Base;

namespace Falcata.BillPlanner.Application.Interfaces.Repositories.Base;

public interface IUpdateCommandRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
}