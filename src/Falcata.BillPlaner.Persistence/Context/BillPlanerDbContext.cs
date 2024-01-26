using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Microsoft.EntityFrameworkCore;

namespace Falcata.BillPlaner.Persistence.Context;

public class BillPlanerDbContext: BaseDbContext, IBillPlanerDbContext
{
    public BillPlanerDbContext(DbContextOptions ctxOptions) : base(ctxOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        base.SetEntityConfigurations(builder, typeof(IBillPlannerEntityTypeConfiguration<>), "dbo");
    }
    
    public DbSet<Account> Accounts { get; set; }
}

public interface IBillPlannerEntityTypeConfiguration<T>
{
}