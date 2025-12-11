namespace Falcata.BillPlanner.Domain.Models.BillLog;

public class MonthlyPayment
{
    private MonthlyPayment() { }
    
    public long MonthlyPaymentId { get; private set; }
    public string Name { get; private set; }
    public int PlannedDay { get; private set; }
    public decimal Amount { get; private set; }
    public bool IsSettled { get; private set; }
    public List<PaymentLog> LinkedPaymentLogs { get; private set; } = new List<PaymentLog>();

    public void LinkPaymentLog(PaymentLog payment)
    {
        LinkedPaymentLogs.Add(payment);
        
        IsSettled = Amount < LinkedPaymentLogs.Sum(p => p.Amount); 
    }

    public void SetAsSettled()
    {
        IsSettled = true;
    }
    
}