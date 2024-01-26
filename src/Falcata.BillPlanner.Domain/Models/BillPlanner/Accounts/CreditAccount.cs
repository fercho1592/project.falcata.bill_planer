using Falcata.BillPlanner.Domain.Enums;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

public class CreditAccount: Account
{
    public override AccountTypeEnum AccountTypeEnum => AccountTypeEnum.Credit;
    
    public static CreditAccount CreateAccount(int userId, string name)
    {
        var result = new CreditAccount()
        {
            UserId = userId,
            Name = name,
            AccountTypeId = (int)Enums.AccountTypeEnum.Credit,
            AccountLimit = null,
            AccountMin = null,
            AccountMovements = new List<AccountMovement>(),
        };

        return result;
    }

    public override decimal CalculateTotalAmountByDate(DateTimeOffset initDate, DateTimeOffset? lastDate = null)
    {
        lastDate ??= initDate.AddMonths(1);
        var movements = AccountMovements?.Where(mov => mov.CreationDate >= initDate && mov.CreationDate < lastDate);
        
        return -1;
    }
}