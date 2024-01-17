namespace Falcata.BillPlaner.Persistence.Context;

public interface IBaseDbContext
{
    Task ExecuteSaveChangesAsync(CancellationToken cancellationToken);
}