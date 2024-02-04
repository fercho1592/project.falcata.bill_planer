using Falcata.BillPlanner.Domain.Enums;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

public class DebitAccount: Account
{
    public override AccountTypeEnum AccountTypeEnum => AccountTypeEnum.Debit;
    
    private DebitAccount(){}
}