using Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;
using Falcata.BillPlanner.Domain.Test.Models.BillPlanner.Accounts.Data;

namespace Falcata.BillPlanner.Domain.Test.Models.BillPlanner.DebtPeriods;

public class DebtPeriodDetailTest
{
    [Fact]
    public void CreateDebtPeriods_PartialAccountMovement_MultipleDebtPeriodDetail()
    {
        short partials = 3;
        var movement = AccountMovementData.SimpleCreditMovement;

        var details = DebtPeriodDetail.CreateDebtPeriodsDetails(movement, partials);
        
        Assert.NotNull(details);
        Assert.Equal(partials, details.Count());
        Assert.Equal(movement.MovementAmount, details.Sum(x => x.Amount));
    }
    
    [Fact]
    public void CreateDebtPeriods_RegularAccountMovement_DebtPeriodDetail()
    {
        var movement = AccountMovementData.SimpleCreditMovement;

        var details = DebtPeriodDetail.CreateDebtPeriodsDetails(movement, 1);
        
        Assert.NotNull(details);
        Assert.Single(details);
        Assert.Equal(movement.MovementAmount, details.Sum(x => x.Amount));
    }
}