using Falcata.BillPlanner.Application.Feature.Accounts.Queries.GetAccountCurrentPeriods;
using Falcata.BillPlanner.Application.Feature.Accounts.Queries.GetAccountsStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Falcata.BillPlanner.API.Controllers;

public class AccountsController: BaseController
{
    private readonly IMediator _mediator;

    public AccountsController(IMediator mediator) : base(mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("list/genera-status")]
    public async Task<List<AccountStatusDto>> GetAccountStatusAsync([FromQuery] DateTimeOffset? from, [FromQuery] DateTimeOffset? to)
    {
        
        from ??= DateTimeOffset.UtcNow.AddDays(-DateTimeOffset.UtcNow.Day);
        return await _mediator.Send(new GetAccountsStatusQuery() {FromDate = from.Value, ToDate = to});
    }
    
    [HttpGet("list/current-period")]
    public async Task<List<AccountCurrentPeriodDto>> GetAccountsCurrentPeriodAsync([FromQuery] DateTimeOffset? from)
    {
        from ??= DateTimeOffset.UtcNow;
        return await _mediator.Send(new GetAccountCurrentPeriodQuery() { CurrentDate = from.Value, AccountTypeId = 1 });
    }
}