using Falcata.BillPlanner.Domain.Models.Base;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

public class Account: BaseEntity<long>
{
    public long AccountId { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public int AccountTypeId { get; set; }
    public int? AccountLimit { get; set; }
    public int? AccountMin { get; set; }
    
    public virtual List<AccountMovement> AccountMovements { get; set; }


    public static Account CreateAccount(int userId, string name, int accountTypeId)
    {
        var result = new Account()
        {
            UserId = userId,
            Name = name,
            AccountTypeId = accountTypeId,
            AccountLimit = null,
            AccountMin = null,
            AccountMovements = new List<AccountMovement>(),
        };

        return result;
    }
}