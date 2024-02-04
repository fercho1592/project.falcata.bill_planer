using Falcata.BillPlanner.Application.Interfaces.QueryBuilders;
using Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;

namespace Falcata.BillPlaner.Persistence.QueryBuilder;

public class DebtPeriodQueryBuilder: BaseQueryBuilder<DebtPeriod>, IDebtPeriodQueryBuilder
{
    public DebtPeriodQueryBuilder(IQueryable<DebtPeriod> queryEntity) : base(queryEntity)
    {
    }
}