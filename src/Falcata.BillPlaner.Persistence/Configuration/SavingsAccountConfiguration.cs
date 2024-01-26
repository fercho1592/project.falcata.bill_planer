using Falcata.BillPlaner.Persistence.Configuration.Base;
using Falcata.BillPlaner.Persistence.Context;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Falcata.BillPlaner.Persistence.Configuration;

public class SavingsAccountConfiguration: BaseEntityTypeConfiguration<SavingsAccount>, IBillPlannerEntityTypeConfiguration<SavingsAccount>
{
    protected override void ConfigureTable(EntityTypeBuilder<SavingsAccount> builder)
    {
        builder.HasBaseType<Account>();
    }

    protected override void ConfigureColumns(EntityTypeBuilder<SavingsAccount> builder)
    {
        
    }
}