using Falcata.BillPlanner.Domain.Models.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriod;

public class DebtPeriod: BaseEntity<long>
{
    public int AccountId { get; set; }
    public DateTimeOffset CutOffDate { get; set; }
    public DateTimeOffset PayDeadlineDate { get; set; }
    public DateTimeOffset InitCutOffDate { get; set; }
    
    public virtual Account Account { get; set; }
}