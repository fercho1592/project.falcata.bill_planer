using Falcata.BillPlanner.Domain.Enums;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

public class DebitAccountMovement: AccountMovement
{
    public override AccountTypeEnum AccountTypeEnum => AccountTypeId switch
    {
        (int) AccountTypeEnum.Savings => AccountTypeEnum.Savings,
        (int) AccountTypeEnum.Debit => AccountTypeEnum.Debit,
        _ => AccountTypeEnum.None,
    };
    
    private DebitAccountMovement(){}
    
    public static AccountMovement Create(int accountId, string detail, decimal amount, decimal oldCurrentAmount)
    {
        return new DebitAccountMovement()
        {
            AccountId = accountId,
            AccountTypeId = (int)AccountTypeEnum.Debit,
            Detail = detail,
            MovementAmount = Math.Round(amount, 2, MidpointRounding.ToPositiveInfinity),
            CurrentAmount = oldCurrentAmount + amount
        };
    }

    public override void SetDebtPeriod(short accountMovementPartials, DateTimeOffset date)
    {
        base.SetDebtPeriod(accountMovementPartials, date);
        
        //
    }
}