using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Microsoft.EntityFrameworkCore;

namespace Falcata.BillPlaner.Persistence.Context;

public class BillPlanerDbContext: BaseDbContext, IBillPlanerDbContext
{
    public BillPlanerDbContext(DbContextOptions ctxOptions) : base(ctxOptions)
    {
    }

    public DbSet<Account> Accounts { get; set; }
}