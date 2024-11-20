using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting.Server;
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

            return services;
        }
    }
}

