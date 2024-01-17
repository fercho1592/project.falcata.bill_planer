using Microsoft.EntityFrameworkCore;

namespace Falcata.BillPlaner.Persistence.Configuration;

public interface IBaseEntityTypeConfiguration<TEntity>: IEntityTypeConfiguration<TEntity>
    where TEntity : class
{
    
}