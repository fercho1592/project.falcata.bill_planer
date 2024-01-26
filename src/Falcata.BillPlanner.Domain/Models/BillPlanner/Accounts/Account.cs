using Falcata.BillPlanner.Domain.Enums;
using Falcata.BillPlanner.Domain.Models.Base;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

public abstract class Account: BaseEntity<long>
{
    public long AccountId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public int AccountTypeId { get; set; }
    public int? AccountLimit { get; set; }
    public int? AccountMin { get; set; }

    public string AccountTypeName => nameof(AccountTypeEnum);
    public abstract AccountTypeEnum AccountTypeEnum { get; }

    public List<AccountMovement> AccountMovements { get; set; }

    public virtual decimal CalculateTotalAmountByDate(DateTimeOffset initDate, DateTimeOffset? lastDate = null)
    {
        lastDate ??= initDate.AddMonths(1);
        var movements = AccountMovements?.Where(mov => mov.CreationDate >= initDate && mov.CreationDate < lastDate);
        
        var lastMovement =movements?.MaxBy(x => x.CreationDate) ?? 
            AccountMovements?.MaxBy(x => x.CreationDate);

        return lastMovement?.CurrentAmount ?? 0;
    }
}