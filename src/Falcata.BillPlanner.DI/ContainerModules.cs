using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Falcata.BillPlanner.DI;

public static class ContainerModules
{
    public static IWebHostBuilder ConfigureDependencies(IWebHostBuilder webHost)
    {
        webHost.ConfigureServices(services =>
        {
            
        });

        return webHost;
    }
}