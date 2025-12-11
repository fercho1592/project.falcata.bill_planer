using Falcata.BillPlanner.Domain.Enums;

namespace Falcata.BillPlanner.Domain.Models.BillLog;

public class MonthlyBudget
{
    private MonthlyBudget() { }

    protected MonthlyBudget(decimal budgetRate, MonthlyBudgetType monthlyTypeId, TagStruct relatedTag)
    {
        MonthlyBudgetRate = budgetRate;
        RemainingBudget = budgetRate;
        MonthlyTypeId = monthlyTypeId;
        RelatedTagId = relatedTag.TagId;
    }
    public long MonthlyBudgetId { get; private set; }
    public decimal MonthlyBudgetRate { get; protected set; }
    public MonthlyBudgetType MonthlyTypeId { get; protected set; }
    public int RelatedTagId { get; protected set; }
    public decimal RemainingBudget { get; protected set; }
    public decimal UsedAmount { get; protected set; }
    public List<PaymentLog> RelatedPaymentLogs { get; private set; } = new List<PaymentLog>();

    public static MonthlyBudget Create(decimal budgetRate, MonthlyBudgetType monthlyTypeId, TagStruct relatedTag)
    {
        var budget = new MonthlyBudget(budgetRate,monthlyTypeId, relatedTag);
        
        budget.CalculateRemainingBudget();

        return budget;
    }

    public void LinkPaymentLog(PaymentLog payment)
    {
        payment.MonthlyBudgetId = MonthlyBudgetId;
        RelatedPaymentLogs.Add(payment);
    }

    public virtual void CalculateRemainingBudget()
    {
        UsedAmount = RelatedPaymentLogs.Sum(x => x.Amount);
        RemainingBudget = MonthlyBudgetRate - UsedAmount;
    }
}