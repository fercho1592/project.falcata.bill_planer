using Falcata.BillPlaner.Persistence.Reflection;
using Falcata.BillPlanner.Application.Reflection;
using Microsoft.AspNetCore.Hosting;

namespace Falcata.BillPlanner.DI;

public static class ContainerModules
{
    [ExcludeFromCodeCoverage]
    public static IWebHostBuilder ConfigureDependencies(IWebHostBuilder webHost)
    {
        webHost.ConfigureServices(services =>
        {
            services.RegisterMediatR(ApplicationAssemblyFinder.GetAssembly());
            services.RegisterPersistenceContainers(PersistenceAssemblyFinder.GetAssembly());
        });

        return webHost;
    }
}