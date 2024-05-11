using Falcata.BillPlanner.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Falcata.BillPlanner.Application.Feature.Accounts.Queries.GetAccountCurrentPeriods;

public class GetAccountCurrentPeriodQueryHandler: IRequestHandler<GetAccountCurrentPeriodQuery, List<AccountCurrentPeriodDto>>
{
    private readonly ILogger<GetAccountCurrentPeriodQueryHandler> _logger;
    private readonly IAccountQueryRepository _accountQueryRepository;

    public GetAccountCurrentPeriodQueryHandler(ILogger<GetAccountCurrentPeriodQueryHandler> logger,
        IAccountQueryRepository accountQueryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _accountQueryRepository = accountQueryRepository ?? throw new ArgumentNullException(nameof(accountQueryRepository));
    }
    
    public async Task<List<AccountCurrentPeriodDto>> Handle(GetAccountCurrentPeriodQuery request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Start {nameof(GetAccountCurrentPeriodQueryHandler)}");

            var query = _accountQueryRepository.NewQueryBuilder()
                .IncludeDebtPeriodAccountMovements(request.CurrentDate)
                .SetPredicate(x => x.AccountTypeId == request.AccountTypeId);

            var queryResult = await _accountQueryRepository.ListAsync(query, cancellationToken);
            var currentDate = DateTimeOffset.UtcNow;

            var result = queryResult.Select(x => new AccountCurrentPeriodDto()
            {
                AccountId = x.AccountId,
                AccountName = x.Name,
                CurrentPeriodYear = x.DebtPeriods?.FirstOrDefault()?.YearCutOffDate ?? currentDate.Year,
                CurrentPeriodMonth = x.DebtPeriods?.FirstOrDefault()?.MonthCutOffDate ?? currentDate.Month,
                AccountTypeName = x.AccountTypeName,
                PeriodTotalAmount = x.DebtPeriods?.FirstOrDefault()?.Details?
                    .Select(detail => detail.Movement)
                    .Where(movement => movement?.MovementAmount > 0)
                    .Sum(am => am?.MovementAmount ?? 0)
            }).ToList();

            return result;
        }
        finally
        {
            _logger.LogInformation($"End {nameof(GetAccountCurrentPeriodQueryHandler)}");
        }
    }
}