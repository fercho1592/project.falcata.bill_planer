using Falcata.BillPlanner.Application.Interfaces.QueryBuilders.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

namespace Falcata.BillPlanner.Application.Interfaces.QueryBuilders;

public interface IAccountQueryBuilder: IQueryBuilder<Account>
{
    public IAccountQueryBuilder IncludeLastAccountMovement();
    public IAccountQueryBuilder IncludeAccountMovementFromDates(DateTimeOffset from, DateTimeOffset to);
    public IAccountQueryBuilder IncludeDebtPeriodAccountMovements(DateTimeOffset from, DateTimeOffset to);
    public IAccountQueryBuilder IncludeUnpaidPromissoryNotes();
}