using MediatR;

namespace Falcata.BillPlanner.Application.Feature.Accounts.Commands.CreateAccount;

public class CreateAccountCommand: IRequest<long>
{
    public string Name { get; set; }
    public int AccountTypeId { get; set; }

    public CreateAccountCommand(string name, int accountTypeId)
    {
        Name = name;
        AccountTypeId = accountTypeId;
    }
}