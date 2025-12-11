using Falcata.BillPlanner.Domain.Enums;

namespace Falcata.BillPlanner.Domain.Models.BillLog.MonthlyBudgetsStrategies;

public class BudgetPerWeek: MonthlyBudget
{
    public decimal PerWeek { get; private set; }
    public DateTimeOffset StartDate { get; private set; }
    public DateTimeOffset EndDate { get; private set; }
    
    private BudgetPerWeek(): base(0,MonthlyBudgetType.Basics, TagStruct.FoodAndBasics) { }

    public static BudgetPerWeek Create(decimal budgetRate, DateTimeOffset startDate, DateTimeOffset endDate)
    {
        var weeks = CalculateWeeksInTwoDates(endDate, startDate);

        return new BudgetPerWeek()
        {
            PerWeek = budgetRate,
            StartDate = startDate,
            EndDate = endDate,
            MonthlyBudgetRate = budgetRate * weeks,
            RemainingBudget = 0,
            MonthlyTypeId = MonthlyBudgetType.Basics,
            RelatedTagId = TagStruct.FoodAndBasics.TagId,
        };
    }

    public override void CalculateRemainingBudget()
    {
        var currentDate = DateTimeOffset.UtcNow;
        if(currentDate < StartDate)
            return;
        
        var weeks = CalculateWeeksInTwoDates(currentDate, StartDate);
        
        UsedAmount = RelatedPaymentLogs.Sum(x => x.Amount);
        RemainingBudget = (PerWeek * weeks) - UsedAmount;
    }

    private static decimal CalculateWeeksInTwoDates(DateTimeOffset endDate, DateTimeOffset startDate)
    {
        var ticks = endDate.Ticks - startDate.Ticks;
        int days = (int) Math.Floor(ticks / (24 * 60 * 60 * 10000000m));
        var weeks = days / 7;
        return weeks;
    }
}