using Falcata.BillPlaner.Persistence.Context;
using Falcata.BillPlaner.Persistence.QueryBuilder;
using Falcata.BillPlaner.Persistence.Repositories.Base;
using Falcata.BillPlanner.Application.Interfaces.QueryBuilders;
using Falcata.BillPlanner.Application.Interfaces.Repositories;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Falcata.BillPlaner.Persistence.Repositories;

public class AccountMovementRepository: BaseRepository<AccountMovement, long, IBillPlanerDbContext>, IAccountMovementQueryRepository, IAccountMovementCommandRepository
{
    public AccountMovementRepository(IBillPlanerDbContext context, ILogger<AccountMovementRepository> logger) : 
        base(context, logger)
    {
    }

    protected override DbSet<AccountMovement> Entities => _context.AccountMovements;
    public IAccountMovementQueryBuilder NewQueryBuilder() 
        => new AccountMovementQueryBuilder(Entities.AsQueryable());
}