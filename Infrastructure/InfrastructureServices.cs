using Infrastructure.DataBase;
using Infrastructure.DataUnitOfWork.Implementations;
using Infrastructure.DataUnitOfWork.Interfaces;
using Infrastructure.StoredProcedureCall;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(DbConnection.DefaultConnection, ServerVersion.AutoDetect(DbConnection.DefaultConnection));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISPCall, SPCall>();

            return services;
        }
    }
}

