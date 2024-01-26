using Falcata.BillPlaner.Persistence.Configuration.Base;
using Falcata.BillPlaner.Persistence.Context;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Falcata.BillPlaner.Persistence.Configuration;

public class CreditAccountConfiguration: BaseEntityTypeConfiguration<CreditAccount>, IBillPlannerEntityTypeConfiguration<CreditAccount>
{
    protected override void ConfigureTable(EntityTypeBuilder<CreditAccount> builder)
    {
        builder.HasBaseType<Account>();
    }

    protected override void ConfigureColumns(EntityTypeBuilder<CreditAccount> builder)
    {
        
    }
}