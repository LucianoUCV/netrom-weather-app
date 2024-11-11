using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetRom.Weather.Core.Persistance;
using NetRom.Weather.Infrastructure.Persistance;
using System.Runtime.CompilerServices;

namespace NetRom.Weather.Infrastructure;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        => services
            .AddScoped(typeof(IRepository<>), typeof(Repository<>))
            .AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
}
