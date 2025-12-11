namespace Falcata.BillPlanner.Domain.Models.BillLog;

public partial class MonthlyPlan
{
    private MonthlyPlan(){}
    
    public int MonthlyPlanId { get; private set; }
    
    public DateTimeOffset InitDate { get; private set; }
    public DateTimeOffset EndDate { get; private set; }
    
    public decimal Budget { get; private set; }
    public decimal UsedCurrentAmount { get; private set; }
    public decimal UsedCurrentAmountWithPlanedAmount { get; private set; }
    public decimal AvailableAmount { get; private set; }
    
    public List<MonthlyBudget> MonthlyBudgets { get; private set; } = new List<MonthlyBudget>();
    public List<MonthlyPayment> MonthlyPayments { get; private set; } = new List<MonthlyPayment>();
    public List<PaymentLog> PaymentLogs { get; private set; } = new List<PaymentLog>();

    public static MonthlyPlan CreatePlan(DateTimeOffset startDate, decimal budget, int plannedDays)
    {
        return new MonthlyPlan()
        {
            InitDate = startDate,
            EndDate = startDate.AddDays(plannedDays),
            Budget = budget,
            UsedCurrentAmount = 0,
            UsedCurrentAmountWithPlanedAmount = 0,
            AvailableAmount = budget,
            MonthlyBudgets = new List<MonthlyBudget>(),
            MonthlyPayments = new List<MonthlyPayment>(),
            PaymentLogs = new List<PaymentLog>(),
        };
    }
}