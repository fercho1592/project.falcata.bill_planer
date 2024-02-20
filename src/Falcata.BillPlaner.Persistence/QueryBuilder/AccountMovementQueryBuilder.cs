using Falcata.BillPlanner.Application.Interfaces.QueryBuilders;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

namespace Falcata.BillPlaner.Persistence.QueryBuilder;

public class AccountMovementQueryBuilder: BaseQueryBuilder<AccountMovement>, IAccountMovementQueryBuilder
{
    public AccountMovementQueryBuilder(IQueryable<AccountMovement> queryEntity) : base(queryEntity)
    {
    }
}