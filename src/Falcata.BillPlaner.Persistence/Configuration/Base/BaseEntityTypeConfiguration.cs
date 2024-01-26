using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Falcata.BillPlaner.Persistence.Configuration.Base;

public abstract class BaseEntityTypeConfiguration<TEntity>: IBaseEntityTypeConfiguration<TEntity> 
    where TEntity: class
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ConfigureTable(builder);
        ConfigureColumns(builder);
    }

    protected abstract void ConfigureTable(EntityTypeBuilder<TEntity> builder);
    protected abstract void ConfigureColumns(EntityTypeBuilder<TEntity> builder);
}