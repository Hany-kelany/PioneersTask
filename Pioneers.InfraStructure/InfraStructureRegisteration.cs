using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pioneers.Core.Interfaces;
using Pioneers.InfraStructure.Data;
using Pioneers.InfraStructure.Repository;

namespace Pioneers.InfraStructure;
public static class InfraStructureRegisteration
{

    public static IServiceCollection InfraStructureConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
        services.AddDbContext<AppDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("defaultconnection")));
        return services;

    }

}