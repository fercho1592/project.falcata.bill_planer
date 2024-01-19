using Microsoft.EntityFrameworkCore;

namespace Falcata.BillPlaner.Persistence.Context;

public class BillPlanerDbContext: BaseDbContext, IBillPlanerDbContext
{
    public BillPlanerDbContext(DbContextOptions ctxOptions) : base(ctxOptions)
    {
    }
}