using Falcata.BillPlanner.Application.Interfaces.Repositories;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Falcata.BillPlanner.Application.Feature.Accounts.Queries.GetAccountsStatus;

public class GetAccountsStatusQueryHandler: IRequestHandler<GetAccountsStatusQuery, List<AccountStatusDto>>
{
    private readonly ILogger<GetAccountsStatusQueryHandler> _logger;
    private readonly IAccountQueryRepository _accountQueryRepository;

    private readonly long _userId = 1;
    
    public GetAccountsStatusQueryHandler(ILogger<GetAccountsStatusQueryHandler> logger,
        IAccountQueryRepository accountQueryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _accountQueryRepository = accountQueryRepository ?? throw new ArgumentNullException(nameof(accountQueryRepository));
    }
    
    public async Task<List<AccountStatusDto>> Handle(GetAccountsStatusQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogTrace($"Start {nameof(GetAccountsStatusQueryHandler)}");

            var query = _accountQueryRepository.NewQueryBuilder()
                .IncludeLastAccountMovement()
                .IncludeUnpaidPromissoryNotes()
                .IncludeDebtPeriodAccountMovements(request.FromDate, request.ToDate ?? request.FromDate.AddMonths(1))
                .NoTracking()
                .SetPredicate(account => account.UserId == _userId);

            var accounts = await _accountQueryRepository.ListAsync(query, cancellationToken);

            var result = new List<AccountStatusDto>();
            
            foreach (var acc in accounts)
            {
                var dto = new AccountStatusDto()
                {
                    AccountId = acc.AccountId,
                    AccountName = acc.Name,
                    AccountTypeName = acc.AccountTypeName,
                    AccountTotalAmount = acc.CalculateTotalAmountByDate(request.FromDate, request.ToDate),
                    Status = string.Empty,
                };
                
                result.Add(dto);
            }

            return result;
        }
        finally
        {
            _logger.LogTrace($"End {nameof(GetAccountsStatusQueryHandler)}");
        }
    }
}