using Falcata.BillPlaner.Persistence.Configuration.Base;
using Falcata.BillPlaner.Persistence.Context;
using Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Falcata.BillPlaner.Persistence.Configuration;

public class DebtPeriodDetailConfiguration: BaseEntityTypeConfiguration<DebtPeriodDetail>, IBillPlannerEntityTypeConfiguration<DebtPeriodDetail>
{
    protected override void ConfigureTable(EntityTypeBuilder<DebtPeriodDetail> builder)
    {
        builder.ToTable("debt_period_detail")
            .HasKey(x => x.DebtPeriodDetailId);

        builder.HasOne(x => x.DebtPeriod)
            .WithMany(x => x.Details)
            .HasForeignKey(x => new { x.AccountId, x.MonthCutOffDate, x.YearCutOffDate});
        
        builder.HasOne(x => x.Movement)
            .WithMany(x => x.DebtPeriodDetails)
            .HasForeignKey(x => x.AccountMovementId);
    }

    protected override void ConfigureColumns(EntityTypeBuilder<DebtPeriodDetail> builder)
    {
        builder.Property(x => x.DebtPeriodDetailId)
            .HasColumnName("debt_period_detail_id")
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.AccountMovementId)
            .HasColumnName("account_movement_id");
        
        builder.Property(x => x.Amount)
            .HasColumnName("amount");
        
        builder.Property(x => x.AccountId)
            .HasColumnName("account_id");
        
        builder.Property(x => x.MonthCutOffDate)
            .HasColumnName("month_debt_Period");
        
        builder.Property(x => x.YearCutOffDate)
            .HasColumnName("year_debt_period");
    }
}