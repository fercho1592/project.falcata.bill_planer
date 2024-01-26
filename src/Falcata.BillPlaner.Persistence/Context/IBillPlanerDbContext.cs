using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Microsoft.EntityFrameworkCore;

namespace Falcata.BillPlaner.Persistence.Context;

public interface IBillPlanerDbContext: IBaseDbContext
{
    DbSet<Account> Accounts { get; set; }
}