namespace Falcata.BillPlanner.Domain.Models.BillLog;

public class PaymentLog
{
    private PaymentLog() {}
    
    public long PaymentLogId { get; private set; }
    public List<int> Tags { get; private set; }
    public int AccountId { get; private set; }
    public int LocationId { get; private set; }
    public string Description { get; private set; }
    public DateTimeOffset Date { get; private set; }
    public decimal Amount { get; private set; }
    public long MonthlyBudgetId { get; internal set; }

    public static PaymentLog CreateLog(int accountId, int locationId, string description, decimal amount, DateTimeOffset? date = null, List<int>? tags = null)
    {
        return new PaymentLog()
        {
            AccountId = accountId,
            LocationId = locationId,
            Description = description,
            Amount = amount,
            Date = date ?? DateTimeOffset.UtcNow,
            Tags = tags ?? new List<int>()
        };
    }
}