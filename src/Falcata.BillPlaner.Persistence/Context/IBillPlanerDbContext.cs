using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;
using Microsoft.EntityFrameworkCore;

namespace Falcata.BillPlaner.Persistence.Context;

public interface IBillPlanerDbContext: IBaseDbContext
{
    DbSet<Account> Accounts { get; set; }
    DbSet<DebtPeriod> DebtPeriods { get; set; }
    DbSet<AccountMovement> AccountMovements { get; set; }
}