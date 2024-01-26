using Falcata.BillPlanner.Domain.Models.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.PromisoryNote;

namespace Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;

public class AccountMovement: BaseEntity<long>
{
    public long AccountMovementId { get; set; }
    public int AccountId { get; set; }
    public string? Detail { get; set; }
    public DateTimeOffset CreationDate { get; set; }
    public decimal MovementAmount { get; set; }
    public decimal CurrentAmount { get; set; }
    public long PromissoryNoteId { get; set; }
    public bool IsLastMovement { get; set; }
    
    public Account? Account { get; set; }
    public PromissoryNote? PromissoryNote { get; set; }
}