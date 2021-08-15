using CaseCore.Application;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Common;
using CaseCore.Infrastructure;
using CaseCore.Persistence;
using CaseCore.WebUI.Common;
using CaseCore.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WebUI
{
    /// <summary>
    /// Configures the Application startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Creates a new instance of the class.
        /// </summary>
        /// <param name="configuration">An implementation of <see cref="IConfiguration"/></param>
        /// <param name="environment">An implementation of <see cref="IWebHostEnvironment"/></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        private IServiceCollection _services;
        /// <summary>
        /// The <see cref="IConfiguration"/>
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// The <see cref="IWebHostEnvironment"/>
        /// </summary>
        public IWebHostEnvironment Environment { get; }
        /// <summary>
        /// Configures the Authentication protocol for the application
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <remarks>
        /// This method can be overridden in derived Startup classes to facilitate testing.
        /// </remarks>
        protected virtual void ConfigureAuth(IServiceCollection services)
        {
            services.AddAuthentication(Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme);
            // TODO: re-implement claims loader
            // services.AddScoped<IClaimsTransformation, ClaimsLoader>();
        }
        /// <summary>
        /// Configures the Application Insights setting, if any.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <remarks>
        /// This method can be overridden in derived Startup classes to facilitate testing.
        /// </remarks>
        protected virtual void ConfigureAppInsights(IServiceCollection services)
        {

        }
        /// <summary>
        /// Configures dependencies.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <remarks>
        /// This method can be overridden in derived Startup classes to facilitate testing.
        /// </remarks>
        protected virtual void ConfigureDependencies(IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IDateTime, DateTimeProvider>();

        }
        /// <summary>
        /// Configures the persistence layer.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <remarks>
        /// This method can be overridden in derived Startup classes to facilitate testing.
        /// </remarks>
        protected virtual void ConfigurePersistence(IServiceCollection services)
        {
            services.AddPersistence(Configuration);
        }
        /// <summary>
        /// Configures the infrastructure layer.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <remarks>
        /// This method can be overridden in derived Startup classes to facilitate testing.
        /// </remarks>
        protected virtual void ConfigureInfrastructure(IServiceCollection services)
        {

            services.AddInfrastructure(Configuration);
        }
        /// <summary>
        /// Configures Swagger
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/></param>
        /// <remarks>
        /// This method can be overridden in derived Startup classes to facilitate testing.
        /// </remarks>
        protected virtual void ConfigureSwagger(IServiceCollection services)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CaseCore API",
                    Description = "A Case Management API built in .NET",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Stringly",
                        Email = "magnificentstringly@gmail.com"
                    }
                });
                //Collect all referenced projects output XML document file paths  
                var currentAssembly = Assembly.GetExecutingAssembly();
                var xmlDocs = currentAssembly.GetReferencedAssemblies()
                .Union(new AssemblyName[] { currentAssembly.GetName() })
                .Select(a => Path.Combine(Path.GetDirectoryName(currentAssembly.Location), $"{a.Name}.xml"))
                .Where(f => File.Exists(f)).ToArray();
                // Set the comments path for the Swagger JSON and UI.
                Array.ForEach(xmlDocs, (d) =>
                {
                    c.IncludeXmlComments(d);
                });
            });
        }
        /// <summary>
        /// Configures the Application's services/
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> that will contain the services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            this.ConfigureAuth(services);
            this.ConfigureAppInsights(services);
            this.ConfigureDependencies(services);
            this.ConfigurePersistence(services);
            this.ConfigureInfrastructure(services);
            this.ConfigureSwagger(services);
            services.AddHttpContextAccessor();            
            services.AddControllersWithViews()
                .AddNewtonsoftJson()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ICaseCoreDbContext>());
            services.AddApplication();
            services.AddHealthChecks()
                .AddDbContextCheck<CaseCoreDbContext>();
            //services.AddMvc(options => options.EnableEndpointRouting = false).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ICaseCoreDbContext>());            
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline. 
        /// </summary>
        /// <param name="app">An implementation of <see cref="IApplicationBuilder"/></param>
        /// <param name="env">An implementation oi <see cref="IWebHostEnvironment"/></param>        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/error-local-development");
                RegisteredServicesPage(app);
            }
            else
            {
                app.UseExceptionHandler("/error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CaseCore API v1");
            });
        }
        /// <summary>
        /// Private method that creates an endpoint to view registered services in Development.
        /// </summary>
        /// <param name="app"></param>
        private void RegisteredServicesPage(IApplicationBuilder app)
        {
            app.Map("/services", builder => builder.Run(async context =>
            {
                var sb = new StringBuilder();
                sb.Append("<h1>Registered Services</h1>");
                sb.Append("<table><thead>");
                sb.Append("<tr><th>Type</th><th>Lifetime</th><th>Instance</th></tr>");
                sb.Append("</thead><tbody>");
                foreach (var svc in _services)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{svc.ServiceType.FullName}</td>");
                    sb.Append($"<td>{svc.Lifetime}</td>");
                    sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
                    sb.Append("</tr>");
                }
                sb.Append("</tbody></table>");
                await context.Response.WriteAsync(sb.ToString());
            }));
        }
    }
}
