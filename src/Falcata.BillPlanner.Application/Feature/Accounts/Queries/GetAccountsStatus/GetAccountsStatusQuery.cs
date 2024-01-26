using MediatR;

namespace Falcata.BillPlanner.Application.Feature.Accounts.Queries.GetAccountsStatus;

public class GetAccountsStatusQuery: IRequest<List<AccountStatusDto>>
{
    public DateTimeOffset FromDate { get; set; }
    public DateTimeOffset? ToDate { get; set; }
}