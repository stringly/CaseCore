using AutoMapper;
using CaseCore.Application.Common.Behaviors;
using CaseCore.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CaseCore.Application
{
    /// <summary>
    /// Configures Dependency Injection for the Application 
    /// </summary>
    public static class DependencyInjection
    {
        /// <summary>
        /// Configures services for the Application layer
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestAuthorizationBehavior<,>));
            services.AddAuthorizersFromAssembly(Assembly.GetAssembly(typeof(Authorization)));
            return services;
        }
    }
}
