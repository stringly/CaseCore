using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CaseCore.Application.Common.Interfaces;

namespace CaseCore.Persistence
{
    /// <summary>
    /// Configures the service dependencies used in the Persistence layer
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configures the service collection
        /// </summary>
        /// <param name="services">An implementation of <see cref="IServiceCollection"></see></param>
        /// <param name="configuration">An implementation of <see cref="IConfiguration"></see></param>
        /// <returns></returns>
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CaseCoreDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OvertimeCoreDatabase")));

            services.AddScoped<ICaseCoreDbContext>(provider => provider.GetService<CaseCoreDbContext>());
            return services;
        }
    }
}
