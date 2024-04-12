using Falcata.BillPlanner.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Falcata.BillPlanner.Application.Feature.AccountMovements.Commands;

public class PutAccountMovementsCommandHandler: IRequestHandler<PutAccountMovementsCommand, bool>
{
    private readonly ILogger<PutAccountMovementsCommandHandler> _logger;
    private readonly IAccountMovementQueryRepository _accountMovementQueryRepository;
    private readonly IAccountMovementCommandRepository _accountMovementCommandRepository;
    private readonly IDebtPeriodQueryRepository _debtPeriodQueryRepository;
    private readonly IDebtPeriodCommandRepository _debtPeriodCommandRepository;

    public PutAccountMovementsCommandHandler(ILogger<PutAccountMovementsCommandHandler> logger,
        IAccountMovementQueryRepository accountMovementQueryRepository, 
        IAccountMovementCommandRepository accountMovementCommandRepository,
        IDebtPeriodQueryRepository debtPeriodQueryRepository,
        IDebtPeriodCommandRepository debtPeriodCommandRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _accountMovementQueryRepository = accountMovementQueryRepository ?? throw new ArgumentNullException(nameof(accountMovementQueryRepository));
        _accountMovementCommandRepository = accountMovementCommandRepository ?? throw new ArgumentNullException(nameof(accountMovementCommandRepository));
        _debtPeriodQueryRepository = debtPeriodQueryRepository ?? throw new ArgumentNullException(nameof(debtPeriodQueryRepository));
        _debtPeriodCommandRepository = debtPeriodCommandRepository ?? throw new ArgumentNullException(nameof(debtPeriodCommandRepository));
    }
    
    public async Task<bool> Handle(PutAccountMovementsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogTrace($"Start {nameof(PutAccountMovementsCommandHandler)}");
            
            foreach (var accountMovement in request.AccountMovements)
            {
                await CreateAccountMovementAsync(accountMovement, cancellationToken);
            }
            
            return true;
        }
        finally
        {
            _logger.LogTrace($"End {nameof(PutAccountMovementsCommandHandler)}");
        }
    }

    private async Task CreateAccountMovementAsync(AccountMovementCommand accountMovement, CancellationToken cancellationToken)
    {
        var query = _accountMovementQueryRepository.NewQueryBuilder()
            .IncludeDebtPeriod()
            .SetPredicate(am => am.AccountId == accountMovement.AccountId && am.IsLastMovement)
            .Tracking();
        
        // Get last movement
        var lastAccountMovement = await _accountMovementQueryRepository.FindAsync(query, cancellationToken);
        if (lastAccountMovement is null)
            return;

        var nextMovement = lastAccountMovement.CreateNewMovement(accountMovement.Description, accountMovement.Amount);

        nextMovement.SetDebtPeriod(accountMovement.Partials, accountMovement.Date);
    }
}