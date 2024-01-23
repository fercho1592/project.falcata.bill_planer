using Falcata.BillPlanner.Application.Interfaces.QueryBuilders;
using Falcata.BillPlanner.Application.Interfaces.QueryBuilders.Base;
using Falcata.BillPlanner.Application.Interfaces.Repositories.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

namespace Falcata.BillPlanner.Application.Interfaces.Repositories;

public interface IAccountQueryRepository: IQueryRepository<Account, long>, IQueryBuilderProvider<IAccountQueryBuilder, Account>
{
    
}