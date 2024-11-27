using Application.Contracts;
using Application.Factories;
using Application.Implementations;
using Domain.Interfaces.CommonInterfaces;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());



            services.AddScoped<IOperationResultFactory, OperationResultFactory>();
            services.AddScoped<IApiResponseFactory, ApiResponseFactory>();


            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ILookupService, LookupService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            return services;
        }
    }
}
