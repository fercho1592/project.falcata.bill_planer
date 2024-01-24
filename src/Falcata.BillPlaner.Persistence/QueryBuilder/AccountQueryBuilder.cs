using Falcata.BillPlanner.Application.Interfaces.QueryBuilders;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

namespace Falcata.BillPlaner.Persistence.QueryBuilder;

public class AccountQueryBuilder: BaseQueryBuilder<Account>, IAccountQueryBuilder
{
    public AccountQueryBuilder(IQueryable<Account> queryEntity) : base(queryEntity)
    {
    }
}