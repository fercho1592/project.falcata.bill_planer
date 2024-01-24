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
    
    public virtual List<AccountMovement> AccountMovements { get; set; }
}