using MediatR;

namespace Falcata.BillPlanner.Application.Feature.Accounts.Queries.GetAccountMovementLists;

public class GetAccountMovementListQuery: IRequest<List<AccountMovementListDto>>
{
    public DateTimeOffset CurrentDate { get; set; } = DateTimeOffset.UtcNow;
    public int AccountTypeId { get; set; }
}