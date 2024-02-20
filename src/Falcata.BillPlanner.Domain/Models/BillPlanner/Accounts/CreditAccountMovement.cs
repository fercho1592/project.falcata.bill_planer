using Falcata.BillPlanner.Domain.Enums;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

public class CreditAccountMovement: AccountMovement
{
    public override AccountTypeEnum AccountTypeEnum => AccountTypeEnum.Credit;
    
    private CreditAccountMovement(){}

    public static AccountMovement Create(int accountId, string detail, decimal amount, decimal oldCurrentAmount)
    {
        return new CreditAccountMovement()
        {
            AccountId = accountId,
            AccountTypeId = (int)AccountTypeEnum.Credit,
            Detail = detail,
            MovementAmount = Math.Round(amount, 2, MidpointRounding.ToPositiveInfinity),
            CurrentAmount = oldCurrentAmount + amount
        };
    }
}