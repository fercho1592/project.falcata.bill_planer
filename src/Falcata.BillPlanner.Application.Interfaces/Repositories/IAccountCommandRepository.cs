using Falcata.BillPlanner.Application.Interfaces.Repositories.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

namespace Falcata.BillPlanner.Application.Interfaces.Repositories;

public interface IAccountCommandRepository: ICreateCommandRepository<Account, long>,
    IUpdateCommandRepository<Account, long>
{
    
}