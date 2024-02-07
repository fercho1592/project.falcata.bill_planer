using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

namespace Falcata.BillPlanner.Domain.Test.Models.BillPlanner.Accounts.Data;

public static class AccountMovementData
{
    public static AccountMovement SimpleMovement
        => AccountMovement.Create(1, "Simple Movement test", 145.33m, 300);
}