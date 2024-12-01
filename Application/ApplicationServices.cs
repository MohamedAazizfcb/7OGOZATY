using Application.Authorization;
using Application.Factories;
using Application.Services;
using Domain.Interfaces;
using Domain.Interfaces.CommonInterfaces;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();



            services.AddScoped<IOperationResultFactory, OperationSingleResultFactory>();
            services.AddScoped<IApiResponseFactory, ApiResponseFactory>();


            services.AddScoped(typeof(ILookupService<>), typeof(LookupService<>)); // Registering the generic service

            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IAuthService, AuthService>();
            //services.AddScoped<ILookupService, LookupService>();
            //services.AddScoped<IDoctorService, DoctorService>();
            //services.AddScoped<IAppointmentService, AppointmentService>();
            //services.AddScoped<IJwtTokenService, JwtTokenService>();
            return services;
        }
    }
}
