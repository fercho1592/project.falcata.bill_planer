using Falcata.BillPlaner.Persistence.Context;
using Falcata.BillPlaner.Persistence.QueryBuilder;
using Falcata.BillPlaner.Persistence.Repositories.Base;
using Falcata.BillPlanner.Application.Interfaces.QueryBuilders;
using Falcata.BillPlanner.Application.Interfaces.Repositories;
using Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Falcata.BillPlaner.Persistence.Repositories;

public class DebtPeriodRepository: BaseRepository<DebtPeriod,(int AccountId, int MonthCutOffDate, int YearCutOffDate), IBillPlanerDbContext>,
    IDebtPeriodQueryRepository,
    IDebtPeriodCommandRepository
{
    public DebtPeriodRepository(IBillPlanerDbContext context, ILogger<DebtPeriodRepository> logger) : base(context, logger)
    {
    }

    protected override DbSet<DebtPeriod> Entities => _context.DebtPeriods;
    public IDebtPeriodQueryBuilder NewQueryBuilder()
    {
        return new DebtPeriodQueryBuilder(Entities.AsQueryable());
    }
}