using Falcata.BillPlaner.Persistence.Configuration.Base;
using Falcata.BillPlaner.Persistence.Context;
using Falcata.BillPlanner.Domain.Models.BillPlanner.DebtPeriods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Falcata.BillPlaner.Persistence.Configuration;

public class DebtPeriodConfiguration: BaseEntityTypeConfiguration<DebtPeriod>, IBillPlannerEntityTypeConfiguration<DebtPeriod>
{
    protected override void ConfigureTable(EntityTypeBuilder<DebtPeriod> builder)
    {
        builder.ToTable("debt_period")
            .HasKey(x => new {x.AccountId, x.MonthCutOffDate, x.YearCutOffDate});

        builder.HasOne(x => x.Account)
            .WithMany(x => x.DebtPeriods)
            .HasForeignKey(x => x.AccountId);
    }

    protected override void ConfigureColumns(EntityTypeBuilder<DebtPeriod> builder)
    {
        builder.Property(x => x.AccountId)
            .HasColumnName("account_id");
        
        builder.Property(x => x.MonthCutOffDate)
            .HasColumnName("month_debt_Period");
        
        builder.Property(x => x.YearCutOffDate)
            .HasColumnName("year_debt_period");
        
        builder.Property(x => x.CutOffDate)
            .HasColumnName("cut_off_date");
        
        builder.Property(x => x.PayDeadlineDate)
            .HasColumnName("pay_deadline_date");
        
        builder.Property(x => x.InitCutOffDate)
            .HasColumnName("init_cut_off_date");
        
        builder.Property(x => x.CumulativeAmount)
            .HasColumnName("cumulative_amount");
    }
}