using Falcata.BillPlanner.Domain.Models.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;

public class DebtPeriod: BaseEntity<(int AccountId, int MonthCutOffDate, int YearCutOffDate)>
{
    public int AccountId { get; private set; }
    public int MonthCutOffDate { get; internal set; }
    public int YearCutOffDate { get; internal set; }
    public DateTimeOffset CutOffDate { get; private set; }
    public DateTimeOffset PayDeadlineDate { get; private set; }
    public DateTimeOffset InitCutOffDate { get; private set; }
    public decimal CumulativeAmount { get; private set; }
    
    public virtual Account Account { get; private set; }
    public virtual List<DebtPeriodDetail>? Details { get; set; }

    // internal virtual List<AccountMovement> AccountMovements { get; set; }
    // public IReadOnlyList<AccountMovement> GetAccountMovements() => AccountMovements;
    
    private DebtPeriod(){}

    public static DebtPeriod Create(int accountId, DateTimeOffset cutOffDate)
    {
        return new()
        {
            AccountId = accountId,
            CutOffDate = cutOffDate,
            MonthCutOffDate = cutOffDate.Month,
            YearCutOffDate = cutOffDate.Year,
            InitCutOffDate = cutOffDate.AddMonths(-1).AddDays(1),
            PayDeadlineDate = cutOffDate.AddDays(20),
        };
    }

    public void SetMovements(List<AccountMovement> accountMovements)
    {
        var debtPeriodDetails = new List<DebtPeriodDetail>();
        
        foreach (var mov in accountMovements)
        {
            if(Details.Exists(x => x.AccountMovementId == mov.AccountMovementId))
               continue;
            
            debtPeriodDetails.AddRange(DebtPeriodDetail.CreateDebtPeriods(mov, 1)); 
        }
        
        Details ??= new List<DebtPeriodDetail>();
        Details.AddRange(debtPeriodDetails);

        foreach (var det in debtPeriodDetails)
        {
            det.SetDebtPeriod(this);
        }
    }

    public List<AccountMovement> FilterValidMovements(List<AccountMovement> accountMovements)
    {
        return accountMovements.Where(mov => 
        { 
            var movDate = mov.CreationDate.DateTime; 
            return movDate >= InitCutOffDate && movDate < CutOffDate;
        }).ToList();
    }
}