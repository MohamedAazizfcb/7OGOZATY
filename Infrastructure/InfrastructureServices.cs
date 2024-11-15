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
            var ConnectionString = "Server = 89.58.39.164; Port = 3306; Database = hogozati; User = tamer; Password =12345;";
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
            });
            return services;
        }
    }
}

