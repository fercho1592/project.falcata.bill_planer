using Falcata.BillPlanner.Domain.Models.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;

public class DebtPeriodDetail : BaseEntity<long>
{
    public long DebtPeriodDetailId { get; private set; }

    public int AccountId { get; internal set; }
    public int MonthCutOffDate { get; internal set; }
    public int YearCutOffDate { get; internal set; }

    public long AccountMovementId { get; internal set; }

    public decimal Amount { get; internal set; }

    public virtual DebtPeriod? DebtPeriod { get; internal set; }
    public virtual AccountMovement? Movement { get; internal set; }

    private DebtPeriodDetail() { }

    public DebtPeriodDetail SetDebtPeriod(DebtPeriod debtPeriod)
    {
        DebtPeriod = debtPeriod;
        MonthCutOffDate = debtPeriod.MonthCutOffDate;
        YearCutOffDate = debtPeriod.YearCutOffDate;

        return this;
    }

    public static IEnumerable<DebtPeriodDetail> CreateDebtPeriods(AccountMovement movement, short periods)
    {
        var partialAmounts = SplitAmountsInPeriods(movement.MovementAmount, periods);

        foreach (var part in partialAmounts)
        {
            yield return new DebtPeriodDetail()
            {
                Movement = movement,
                Amount = part
            }; 
        }
    }

    private static IEnumerable<decimal> SplitAmountsInPeriods(decimal totalAmount, short periods)
    {
        if (periods == 0 || periods == 1)
            yield return totalAmount;

        var perPeriod = totalAmount / periods;

        for (int i = 0; i < periods; i++)
        {
            if (i == 0)
                yield return Math.Round(perPeriod, 2, MidpointRounding.AwayFromZero);
            yield return Math.Round(perPeriod, 2, MidpointRounding.ToEven);
        }
    }
}