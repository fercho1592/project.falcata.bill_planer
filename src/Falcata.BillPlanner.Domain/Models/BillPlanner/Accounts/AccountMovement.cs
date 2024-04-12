using Falcata.BillPlanner.Domain.Enums;
using Falcata.BillPlanner.Domain.Models.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;
using Falcata.BillPlanner.Domain.Models.BillPlanner.PromisoryNote;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

public abstract class AccountMovement: BaseEntity<long>
{
    public long AccountMovementId { get; private set; }
    public int AccountId { get; protected set; }
    public int AccountTypeId { get; protected set; }
    public abstract AccountTypeEnum AccountTypeEnum { get; }
    public string? Detail { get; protected set; }
    public DateTimeOffset CreationDate { get; protected set; }
    public decimal MovementAmount { get; protected set; }
    public decimal CurrentAmount { get; protected set; }
    public long PromissoryNoteId { get; protected set; }
    public bool IsLastMovement { get; protected set; }
    
    public virtual Account? Account { get; set; }
    public virtual PromissoryNote? PromissoryNote { get; set; }
    public virtual List<DebtPeriodDetail>? DebtPeriodDetails { get; set; }

    internal AccountMovement(){}

    public static AccountMovement CreateMovement(int accountId, int accountTypeId, string detail, decimal amount, decimal oldCurrentAmount)
    {
        if (accountTypeId == (int) AccountTypeEnum.Credit)
            return CreditAccountMovement.Create(accountId, detail, amount, oldCurrentAmount);
        return DebitAccountMovement.Create(accountId, detail, amount, oldCurrentAmount);
    }

    public virtual AccountMovement CreateNewMovement(string detail, decimal amount)
    {
        IsLastMovement = false;

        return CreateMovement(AccountId, AccountTypeId, detail, amount, CurrentAmount);
    }

    public virtual void SetDebtPeriod(short accountMovementPartials, DateTimeOffset date)
    {
        CreationDate = date;
    }
}