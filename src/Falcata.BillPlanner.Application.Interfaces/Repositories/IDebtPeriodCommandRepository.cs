using Falcata.BillPlanner.Application.Interfaces.Repositories.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;

namespace Falcata.BillPlanner.Application.Interfaces.Repositories;

public interface IDebtPeriodCommandRepository: ICreateCommandRepository<DebtPeriod, (int AccountId, int MonthCutOffDate, int YearCutOffDate)>, IUpdateCommandRepository<DebtPeriod, (int AccountId, int MonthCutOffDate, int YearCutOffDate)>
{
    
}