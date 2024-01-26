using Falcata.BillPlaner.Persistence.Configuration.Base;
using Falcata.BillPlaner.Persistence.Context;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Falcata.BillPlanner.Domain.Models.BillPlanner.PromisoryNote;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Falcata.BillPlaner.Persistence.Configuration;

public class AccountMovementConfiguration: BaseEntityTypeConfiguration<AccountMovement>, IBillPlannerEntityTypeConfiguration<AccountMovement>
{
    protected override void ConfigureTable(EntityTypeBuilder<AccountMovement> builder)
    {
        builder.ToTable("account_movement")
            .HasKey(x => x.AccountMovementId);

        builder.HasOne(x => x.Account)
            .WithMany(x => x.AccountMovements)
            .HasForeignKey(x => x.AccountId);

        builder.HasOne(x => x.PromissoryNote)
            .WithMany(x => x.AccountMovements)
            .HasForeignKey(x => x.PromissoryNoteId);
    }

    protected override void ConfigureColumns(EntityTypeBuilder<AccountMovement> builder)
    {
        builder.Property(x => x.AccountMovementId)
            .HasColumnName("account_movement_id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.AccountId)
            .HasColumnName("account_id");
        
        builder.Property(x => x.Detail)
            .HasColumnName("movement_detail");
        
        builder.Property(x => x.CreationDate)
            .HasColumnName("creation_date");
        
        builder.Property(x => x.MovementAmount)
            .HasColumnName("movement_amount");
        
        builder.Property(x => x.CurrentAmount)
            .HasColumnName("account_current_amount");
        
        builder.Property(x => x.PromissoryNoteId)
            .HasColumnName("promissory_note_id");
    }
}