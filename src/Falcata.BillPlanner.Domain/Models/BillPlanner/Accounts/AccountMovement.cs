using Falcata.BillPlanner.Domain.Models.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;
using Falcata.BillPlanner.Domain.Models.BillPlanner.PromisoryNote;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

public class AccountMovement: BaseEntity<long>
{
    public long AccountMovementId { get; private set; }
    public long AccountId { get; set; }
    public int AccountTypeId { get; private set; }
    public string? Detail { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public decimal MovementAmount { get; set; }
    public decimal CurrentAmount { get; set; }
    public long PromissoryNoteId { get; set; }
    public bool IsLastMovement { get; set; }
    
    public virtual Account? Account { get; set; }
    public virtual PromissoryNote? PromissoryNote { get; set; }
    public virtual List<DebtPeriodDetail>? DebtPeriodDetails { get; set; }

    internal AccountMovement(){}

    public static AccountMovement Create(int accountId, int accountTypeId, string detail, decimal amount, decimal oldCurrentAmount)
    {
        return new AccountMovement()
        {
            AccountId = accountId,
            AccountTypeId = accountTypeId,
            Detail = detail,
            MovementAmount = Math.Round(amount, 2, MidpointRounding.ToPositiveInfinity),
            CurrentAmount = oldCurrentAmount + amount
        };
    }
}