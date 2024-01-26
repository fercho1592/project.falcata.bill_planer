using Falcata.BillPlaner.Persistence.Configuration.Base;
using Falcata.BillPlaner.Persistence.Context;
using Falcata.BillPlanner.Domain.Enums;
using Falcata.BillPlanner.Domain.Models.BillPlanner.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Falcata.BillPlaner.Persistence.Configuration;

public class AccountConfiguration: BaseEntityTypeConfiguration<Account>, IBillPlannerEntityTypeConfiguration<Account>
{
    protected override void ConfigureTable(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("account")
            .HasKey(x => x.AccountId);
        
        builder.HasDiscriminator(account => account.AccountTypeId)
            .HasValue<CreditAccount>((int)AccountTypeEnum.Credit)
            .HasValue<DebitAccount>((int)AccountTypeEnum.Debit)
            .HasValue<SavingsAccount>((int)AccountTypeEnum.Savings);
    }

    protected override void ConfigureColumns(EntityTypeBuilder<Account> builder)
    {
        builder.Property(x => x.AccountId)
            .HasColumnName("account_id")
            .ValueGeneratedOnAdd();

        builder.Property(x => x.UserId)
            .HasColumnName("user_id");
        
        builder.Property(x => x.Name)
            .HasColumnName("account_name");
        
        builder.Property(x => x.AccountTypeId)
            .HasColumnName("account_type_id");
        
        builder.Property(x => x.AccountLimit)
            .HasColumnName("account_limit");
        
        builder.Property(x => x.AccountMin)
            .HasColumnName("account_min");

        builder.Ignore(x => x.AccountTypeEnum);
    }
}