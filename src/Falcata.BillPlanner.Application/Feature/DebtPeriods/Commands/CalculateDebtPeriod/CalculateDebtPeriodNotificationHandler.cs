using Falcata.BillPlanner.Application.Interfaces.Repositories;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Falcata.BillPlanner.Application.Feature.DebtPeriods.Commands.CalculateDebtPeriod;

public class CalculateDebtPeriodNotificationHandler: IRequestHandler<CalculateDebtPeriodNotification,bool>
{
    private readonly ILogger<CalculateDebtPeriodNotificationHandler> _logger;
    private readonly IDebtPeriodQueryRepository _debtPeriodQueryRepository;
    private readonly IDebtPeriodCommandRepository _debtPeriodCommandRepository;
    private readonly IAccountQueryRepository _accountQueryRepository;

    public CalculateDebtPeriodNotificationHandler(ILogger<CalculateDebtPeriodNotificationHandler> logger, 
        IDebtPeriodQueryRepository debtPeriodQueryRepository,
        IDebtPeriodCommandRepository debtPeriodCommandRepository,
        IAccountQueryRepository accountQueryRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _debtPeriodQueryRepository = debtPeriodQueryRepository ?? throw new ArgumentNullException(nameof(debtPeriodQueryRepository));
        _debtPeriodCommandRepository = debtPeriodCommandRepository ?? throw new ArgumentNullException(nameof(debtPeriodCommandRepository));
        _accountQueryRepository = accountQueryRepository ?? throw new ArgumentNullException(nameof(accountQueryRepository));
    }
    
    public async Task<bool> Handle(CalculateDebtPeriodNotification request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogTrace($"Start {nameof(CalculateDebtPeriodNotificationHandler)}");

            var debtPeriod = await GetDebtPeriodAsync(request, cancellationToken);

            var movements = await GetAccountMovementsAsync(debtPeriod.InitCutOffDate, debtPeriod.CutOffDate, debtPeriod.AccountId, cancellationToken);
            movements = debtPeriod.FilterValidMovements(movements);
            debtPeriod.SetMovements(movements);

            await _debtPeriodCommandRepository.UpdateAsync(debtPeriod, cancellationToken);

            return true;
        }
        finally
        {
            _logger.LogTrace($"End {nameof(CalculateDebtPeriodNotificationHandler)}");
        }
    }

    private async Task<List<AccountMovement>> GetAccountMovementsAsync(DateTimeOffset initCutOffDate, DateTimeOffset cutOffDate, 
        long accountId, CancellationToken cancellationToken)
    {
        var query = _accountQueryRepository.NewQueryBuilder()
            .IncludeAccountMovementFromDates(initCutOffDate, cutOffDate)
            .NoTracking()
            .SetPredicate(account => account.AccountId == accountId);

        var account = (await _accountQueryRepository.ListAsync(query, cancellationToken)).FirstOrDefault();

        if (account is null)
            throw new NullReferenceException($"Account not found for Id:{accountId}");

        return account.AccountMovements.ToList();
    }

    private async Task<DebtPeriod> GetDebtPeriodAsync(CalculateDebtPeriodNotification request, CancellationToken cancellationToken)
    {
        var query = _debtPeriodQueryRepository.NewQueryBuilder()
            .NoTracking()
            .SetPredicate(dp => 
                dp.AccountId == request.AccountId 
                && dp.CutOffDate.Month == request.MonthCutOff.Month 
                && dp.CutOffDate.Year == request.MonthCutOff.Year);

        var debtPeriod = (await _debtPeriodQueryRepository.ListAsync(query, cancellationToken))
            .FirstOrDefault();

        if (debtPeriod is null)
        {
            debtPeriod = DebtPeriod.Create(request.AccountId, request.MonthCutOff);

            await _debtPeriodCommandRepository.CreateAsync(debtPeriod, cancellationToken);
        }

        return debtPeriod;
    }
}