namespace Falcata.BillPlanner.Application.Feature.Accounts.Queries.GetAccountsStatus;

public class AccountStatusDto
{
    public long AccountId { get; set; }
    public string? AccountTypeName { get; set; }
    public string? AccountName { get; set; }
    public decimal AccountTotalAmount { get; set; }
    public string? Status { get; set; }
}