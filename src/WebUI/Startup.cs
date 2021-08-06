using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaseCore.Application;
using CaseCore.Application.Common.Interfaces;
using CaseCore.Common;
using CaseCore.Infrastructure;
using CaseCore.Persistence;
using CaseCore.WebUI.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        private IServiceCollection _services;
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }


        protected virtual void ConfigureAuth(IServiceCollection services)
        {
            services.AddAuthentication(Microsoft.AspNetCore.Server.IISIntegration.IISDefaults.AuthenticationScheme);
            //services.AddScoped<IClaimsTransformation, ClaimsLoader>();
        }
        protected virtual void ConfigureAppInsights(IServiceCollection services)
        {

        }
        protected virtual void ConfigureDependencies(IServiceCollection services)
        {
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IDateTime, DateTimeProvider>();

        }
        protected virtual void ConfigurePersistence(IServiceCollection services)
        {
            services.AddPersistence(Configuration);
        }
        protected virtual void ConfigureInfrastructure(IServiceCollection services)
        {

            services.AddInfrastructure(Configuration);
        }        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.ConfigureAuth(services);
            this.ConfigureAppInsights(services);
            this.ConfigureDependencies(services);
            this.ConfigurePersistence(services);
            this.ConfigureInfrastructure(services);
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
            services.AddApplication();
            services.AddHealthChecks()
                .AddDbContextCheck<CaseCoreDbContext>();
            services.AddMvc(options => options.EnableEndpointRouting = false).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ICaseCoreDbContext>());
            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                RegisteredServicesPage(app);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
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
        }
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
