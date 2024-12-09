﻿using Application.Authorization;
using Application.Contracts;
using Application.Contracts.Authentication;
using Application.Contracts.Lookups;
using Application.Factories;
using Application.Services;
using Application.Services.Authentication;
using Application.Services.Lookups;
using Domain.Interfaces.CommonInterfaces;
using Domain.Interfaces.CommonInterfaces.OperationResultFactoryInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();



            services.AddScoped<IOperationResultFactory, OperationSingleResultFactory>();
            services.AddScoped<IApiResponseFactory, ApiResponseFactory>();


            services.AddScoped(typeof(ILookupService<,,>), typeof(LookupService<,,>));
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IGovernorateService, GovernorateService>();

            services.AddScoped<IAuthenticationService, AuthentictionService>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();

            services.AddScoped<IClinicService, ClinicService>();


            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<ILookupService, LookupService>();
            //services.AddScoped<IDoctorService, DoctorService>();
            //services.AddScoped<IAppointmentService, AppointmentService>();
            return services;
        }
    }
}
