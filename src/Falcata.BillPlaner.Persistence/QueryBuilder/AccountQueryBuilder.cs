using Falcata.BillPlanner.Application.Interfaces.QueryBuilders;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Microsoft.EntityFrameworkCore;

namespace Falcata.BillPlaner.Persistence.QueryBuilder;

public class AccountQueryBuilder: BaseQueryBuilder<Account>, IAccountQueryBuilder
{
    public AccountQueryBuilder(IQueryable<Account> queryEntity) : base(queryEntity)
    {
    }

    public IAccountQueryBuilder IncludeLastAccountMovement()
    {
        Query = Query.Include(x => x.AccountMovements.Where(mov => mov.IsLastMovement));
        
        return this;
    }

    public IAccountQueryBuilder IncludeAccountMovementFromDates(DateTimeOffset from, DateTimeOffset to)
    {
        Query = Query.Include(acc => acc.AccountMovements.Where(
            mov => mov.CreationDate >= from && mov.CreationDate < to));

        return this;
    }

    public IAccountQueryBuilder IncludeDebtPeriodAccountMovements(DateTimeOffset from, DateTimeOffset to)
    {
        Query = Query.Include(x => x.DebtPeriods!.Where(period => period.CutOffDate > to && period.CutOffDate < from));
        
        return this;
    }

    public IAccountQueryBuilder IncludeUnpaidPromissoryNotes()
    {
        Query = Query.Include(x => x.PromissoryNotes!.Where(note => 
            note.AccountMovements != null 
            && note.AccountMovements.Sum(move => move.MovementAmount) < note.Amount));
        
        return this;
    }
}