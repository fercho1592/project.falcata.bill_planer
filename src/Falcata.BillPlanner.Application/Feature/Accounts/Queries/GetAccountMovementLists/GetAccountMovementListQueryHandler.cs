using Falcata.BillPlanner.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Falcata.BillPlanner.Application.Feature.Accounts.Queries.GetAccountMovementLists;

public class GetAccountMovementListQueryHandler: IRequestHandler<GetAccountMovementListQuery, List<AccountMovementListDto>>
{
    private readonly ILogger<GetAccountMovementListQueryHandler> _logger;
    private readonly IAccountQueryRepository _accountQueryRepository;

    public GetAccountMovementListQueryHandler(ILogger<GetAccountMovementListQueryHandler> logger,
        IAccountQueryRepository accountQueryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _accountQueryRepository = accountQueryRepository ?? throw new ArgumentNullException(nameof(accountQueryRepository));
    }
    
    public async Task<List<AccountMovementListDto>> Handle(GetAccountMovementListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogTrace($"Start {nameof(GetAccountMovementListQueryHandler)}");

            var query = _accountQueryRepository.NewQueryBuilder()
                .IncludeDebtPeriodAccountMovements(request.CurrentDate)
                .SetPredicate(x => x.AccountTypeId == request.AccountTypeId);
            
            var queryResult = await _accountQueryRepository.ListAsync(query, cancellationToken);
            var currentDate = DateTimeOffset.UtcNow;
            
            var result = queryResult.Select(x => new AccountMovementListDto()
            {
                AccountId = x.AccountId,
                AccountName = x.Name,
                CurrentPeriodYear = x.DebtPeriods?.FirstOrDefault()?.YearCutOffDate ?? currentDate.Year,
                CurrentPeriodMonth = x.DebtPeriods?.FirstOrDefault()?.MonthCutOffDate ?? currentDate.Month,
                AccountTypeName = x.AccountTypeName, 
                Movements= x.DebtPeriods?.FirstOrDefault()?.Details?
                    .Select(detail => detail.Movement)
                    .Where(movement => movement?.MovementAmount > 0)
                    .Select(mov => new AccountMovementDto()
                    {
                        
                    })
                    .ToList()
            }).ToList();

            return result;
        }
        finally
        {
            _logger.LogTrace($"End {nameof(GetAccountMovementListQueryHandler)}");
        }
    }
}