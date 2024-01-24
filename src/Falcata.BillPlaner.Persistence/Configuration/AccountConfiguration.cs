using Falcata.BillPlanner.Domain.Enums;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Falcata.BillPlaner.Persistence.Configuration;

public class AccountConfiguration: BaseEntityTypeConfiguration<Account>
{
    protected override void ConfigureTable(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("account")
            .HasDiscriminator(account => account.AccountTypeId)
            .HasValue<CreditAccount>((int)AccountTypeEnum.Credit)
            .HasValue<DebitAccount>((int)AccountTypeEnum.Debit)
            .HasValue<SavingsAccount>((int)AccountTypeEnum.Savings);
    }

    protected override void ConfigureColumns(EntityTypeBuilder<Account> builder)
    {
        throw new NotImplementedException();
    }
}