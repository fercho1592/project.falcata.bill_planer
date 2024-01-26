using Falcata.BillPlanner.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Falcata.BillPlanner.Application.Feature.Accounts.Commands.CreateAccount;

public class CreateAccountCommandHandler: IRequestHandler<CreateAccountCommand, long>
{
    private readonly ILogger<CreateAccountCommand> _logger;
    private readonly IAccountCommandRepository _accountCommandRepository;

    public CreateAccountCommandHandler(ILogger<CreateAccountCommand> logger,
        IAccountCommandRepository accountCommandRepository)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _accountCommandRepository = accountCommandRepository ?? throw new ArgumentNullException(nameof(accountCommandRepository));
    }
    
    public Task<long> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogTrace($"Start {nameof(CreateAccountCommandHandler)}");
            
            
            throw new NotImplementedException();
        }
        finally
        {
            _logger.LogTrace($"End {nameof(CreateAccountCommandHandler)}");
        }
    }
}