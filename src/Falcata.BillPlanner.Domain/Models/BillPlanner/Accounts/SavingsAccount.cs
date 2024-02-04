using Falcata.BillPlanner.Domain.Enums;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

public class SavingsAccount: Account
{
    public override AccountTypeEnum AccountTypeEnum => AccountTypeEnum.Savings;
    
    private SavingsAccount(){}
}