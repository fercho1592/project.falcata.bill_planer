namespace Falcata.BillPlanner.Application.Feature.Accounts.Queries.GetAccountCurrentPeriods;

public class AccountCurrentPeriodDto
{
    public long AccountId { get; set; }
    public string? AccountTypeName { get; set; }
    public string? AccountName { get; set; }
    
    public int CurrentPeriodMonth { get; set; }
    public int CurrentPeriodYear { get; set; }
    public decimal? PeriodTotalAmount { get; set; }
}