using Falcata.BillPlanner.Application.Interfaces.QueryBuilders;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Microsoft.EntityFrameworkCore;

namespace Falcata.BillPlaner.Persistence.QueryBuilder;

public class AccountMovementQueryBuilder: BaseQueryBuilder<AccountMovement>, IAccountMovementQueryBuilder
{
    public AccountMovementQueryBuilder(IQueryable<AccountMovement> queryEntity) : base(queryEntity)
    {
    }

    public IAccountMovementQueryBuilder IncludeDebtPeriod()
    {
        Query = Query.Include(x => x.DebtPeriodDetails)!
            .ThenInclude(x => x.DebtPeriod);

        return this;
    }
}