using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interface;
using API.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            //the cores header service, will allow request to go through
            services.AddCors();

            services.AddScoped<ITokenService, TokenService>();

            //everything that is injected after it have been called it will be disposed of in memory automatic via the framework.
            services.AddDbContext<DataContext>(opt =>
            {
                //the connection string, allows you to talk to the database
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}