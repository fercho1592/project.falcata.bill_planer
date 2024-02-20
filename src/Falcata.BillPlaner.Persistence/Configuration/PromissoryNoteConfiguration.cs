using Falcata.BillPlaner.Persistence.Configuration.Base;
using Falcata.BillPlaner.Persistence.Context;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Falcata.BillPlanner.Domain.Models.BillPlanner.PromisoryNote;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Falcata.BillPlaner.Persistence.Configuration;

public class PromissoryNoteConfiguration: BaseEntityTypeConfiguration<PromissoryNote>, IBillPlannerEntityTypeConfiguration<PromissoryNote>
{
    protected override void ConfigureTable(EntityTypeBuilder<PromissoryNote> builder)
    {
        builder.ToTable("promissory_note")
            .HasKey(x => x.PromissoryNoteId);

        builder.HasOne(x => x.Account)
            .WithMany(x => x.PromissoryNotes)
            .HasForeignKey(x => new {x.AccountId, x.AccountTypeId});
    }

    protected override void ConfigureColumns(EntityTypeBuilder<PromissoryNote> builder)
    {
        builder.Property(x => x.AccountId)
            .HasColumnName("account_id");
        
        builder.Property(x => x.AccountTypeId)
            .HasColumnName("account_type_id");
        
        builder.Property(x => x.PromissoryNoteId)
            .HasColumnName("promissory_note_id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Amount)
            .HasColumnName("amount");
        
        builder.Property(x => x.Note)
            .HasColumnName("note");
        
        builder.Property(x => x.DeadlineDate)
            .HasColumnName("deadline_date");
    }
}