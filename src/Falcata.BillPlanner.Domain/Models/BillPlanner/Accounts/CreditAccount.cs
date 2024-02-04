using Falcata.BillPlanner.Domain.Enums;
using Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

public class CreditAccount: Account
{
    public override AccountTypeEnum AccountTypeEnum => AccountTypeEnum.Credit;
    
    private CreditAccount(){}
    
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
        var debtPeriods = (DebtPeriods ?? new List<DebtPeriod>())
            .Where(x => x.CutOffDate >= initDate && x.CutOffDate < lastDate).ToList();
        
        return debtPeriods.Sum(x => x.CumulativeAmount);
    }
}