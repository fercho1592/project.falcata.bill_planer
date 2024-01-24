using Falcata.BillPlaner.Persistence.Context;
using Falcata.BillPlaner.Persistence.QueryBuilder;
using Falcata.BillPlaner.Persistence.Repositories.Base;
using Falcata.BillPlanner.Application.Interfaces.QueryBuilders;
using Falcata.BillPlanner.Application.Interfaces.Repositories;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Falcata.BillPlaner.Persistence.Repositories;

public class AccountRepository: BaseRepository<Account, long, BillPlanerDbContext>, IAccountQueryRepository, IAccountCommandRepository
{
    protected override DbSet<Account> Entities => _context.Accounts;

    public AccountRepository(BillPlanerDbContext context, ILogger<AccountRepository> logger) : base(context, logger)
    {
    }

    public IAccountQueryBuilder NewQueryBuilder()
    {
        return new AccountQueryBuilder(Entities.AsQueryable());
    }
}