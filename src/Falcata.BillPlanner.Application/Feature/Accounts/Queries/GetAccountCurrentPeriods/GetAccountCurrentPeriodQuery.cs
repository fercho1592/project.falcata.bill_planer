using MediatR;

namespace Falcata.BillPlanner.Application.Feature.Accounts.Queries.GetAccountCurrentPeriods;

public class GetAccountCurrentPeriodQuery: IRequest<List<AccountCurrentPeriodDto>>
{
    public DateTimeOffset CurrentDate { get; set; } = DateTimeOffset.UtcNow;
    public int AccountTypeId { get; set; }
}