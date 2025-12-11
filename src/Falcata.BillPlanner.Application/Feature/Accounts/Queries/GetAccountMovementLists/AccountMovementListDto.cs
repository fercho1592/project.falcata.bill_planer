namespace Falcata.BillPlanner.Application.Feature.Accounts.Queries.GetAccountMovementLists;

public class AccountMovementListDto
{
    public long AccountId { get; set; }
    public string? AccountTypeName { get; set; }
    public string? AccountName { get; set; }
    
    public int CurrentPeriodMonth { get; set; }
    public int CurrentPeriodYear { get; set; }
    public List<AccountMovementDto>? Movements { get; set; }
}

