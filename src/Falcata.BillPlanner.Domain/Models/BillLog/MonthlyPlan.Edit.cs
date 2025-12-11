namespace Falcata.BillPlanner.Domain.Models.BillLog;

public partial class MonthlyPlan
{
    public void AddPaymentLog(int accountId, int locationId, string description, decimal amount, int tag, DateTimeOffset? date = null, long? monthlyPaymentId = null)
    {
        //create payment log
        var payment = PaymentLog.CreateLog(accountId, locationId, description, amount, date, new List<int> { tag });
        //add to list
        PaymentLogs.Add(payment);
        
        var relatedBudget = MonthlyBudgets.FirstOrDefault(b => b.RelatedTagId == tag);
        if (relatedBudget is not null)
            relatedBudget.LinkPaymentLog(payment);
        
        var monthlyPayment = MonthlyPayments.FirstOrDefault(b => b.MonthlyPaymentId == monthlyPaymentId);
        if (monthlyPayment is not null)
            monthlyPayment.LinkPaymentLog(payment);

        //calculate amounts
        CalculateAmounts();
    }

    public void AddMonthlyPayments(params MonthlyPayment[] monthlyPayments)
    {
        MonthlyPayments.AddRange(monthlyPayments);
    }

    public void AddMonthlyBudgets(params MonthlyBudget[] monthlyBudgets)
    {
        MonthlyBudgets.AddRange(monthlyBudgets);
    }

    private void CalculateAmounts()
    {
        UsedCurrentAmount = PaymentLogs.Sum(p => p.Amount);
        var calculatedBudgetAmount = MonthlyBudgets.Sum(x => x.RemainingBudget);
        var calculateMonthlyPayment = MonthlyPayments.Where(x => x.IsSettled).Sum(x => x.Amount);

        UsedCurrentAmountWithPlanedAmount = UsedCurrentAmount + calculatedBudgetAmount + calculateMonthlyPayment;
        AvailableAmount = Budget - UsedCurrentAmountWithPlanedAmount;
    }
}