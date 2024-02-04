using MediatR;

namespace Falcata.BillPlanner.Application.Feature.DebtPeriods.Commands.CalculateDebtPeriod;

public class CalculateDebtPeriodNotification: IRequest<bool>
{
    public int AccountId { get; set; }
    public DateTime MonthCutOff { get; set; }
}