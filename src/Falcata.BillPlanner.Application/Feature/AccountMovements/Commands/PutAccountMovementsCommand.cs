using MediatR;

namespace Falcata.BillPlanner.Application.Feature.AccountMovements.Commands;

public class PutAccountMovementsCommand: IRequest<bool>
{
    public List<AccountMovementCommand> AccountMovements { get; set; } = new();
}

public class AccountMovementCommand
{
    public int AccountId { get; set; }
    public decimal Amount { get; set; }
    public short Partials { get; set; } = 1;
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
}

