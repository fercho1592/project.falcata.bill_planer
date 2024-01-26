using Falcata.BillPlaner.Persistence.Configuration.Base;
using Falcata.BillPlaner.Persistence.Context;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Falcata.BillPlaner.Persistence.Configuration;

public class DebitAccountConfiguration: BaseEntityTypeConfiguration<DebitAccount>, IBillPlannerEntityTypeConfiguration<DebitAccount>
{
    protected override void ConfigureTable(EntityTypeBuilder<DebitAccount> builder)
    {
        builder.HasBaseType<Account>();
    }

    protected override void ConfigureColumns(EntityTypeBuilder<DebitAccount> builder)
    {
        
    }
}