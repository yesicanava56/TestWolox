using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Wolox.Application.Services;
using Test.Wolox.Data;
using Test.Wolox.Data.Repository;
using Test.Wolox.Domain.Services;

namespace Test.Wolox.Api.DependencyInjection
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // Application
            services.AddScoped<ITestWoloxApplicationService, TestWoloxApplicationService>();

            // Infra - Data
            services.AddScoped<IUserClient, UserClient>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPermitsRepository, PermitsRepository>();


            //Domain
            services.AddScoped<ITestWoloxDomainService, TestWoloxDomainService>();
        }
    }
}
