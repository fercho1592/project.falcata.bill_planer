using Falcata.BillPlanner.Domain.Models.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.PromisoryNote;

public class PromissoryNote: BaseEntity<long>
{
    public long PromissoryNoteId { get; set; }
    public int AccountId { get; set; }
    public decimal Amount { get; set; }
    public string? Note { get; set; }
    public DateTimeOffset DeadlineDate { get; set; }
    public List<AccountMovement>? AccountMovements { get; set; }
    public Account Account { get; set; }
    
}