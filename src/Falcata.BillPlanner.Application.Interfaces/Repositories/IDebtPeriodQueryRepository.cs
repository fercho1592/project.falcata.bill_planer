using Falcata.BillPlanner.Application.Interfaces.QueryBuilders;
using Falcata.BillPlanner.Application.Interfaces.QueryBuilders.Base;
using Falcata.BillPlanner.Application.Interfaces.Repositories.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;

namespace Falcata.BillPlanner.Application.Interfaces.Repositories;

public interface IDebtPeriodQueryRepository: IQueryRepository<DebtPeriod, (int AccountId, int MonthCutOffDate, int YearCutOffDate)>, IQueryBuilderProvider<IDebtPeriodQueryBuilder, DebtPeriod>
{
    
}