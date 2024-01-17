using Falcata.BillPlanner.Domain.Models.Base;

namespace Falcata.BillPlanner.Application.Interfaces.Repositories.Base;

public interface ICreateCommandRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    Task<bool> CreateAsync(TEntity entity, CancellationToken cancellationToken);
}