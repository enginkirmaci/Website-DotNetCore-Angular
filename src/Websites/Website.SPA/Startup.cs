using Common.Web.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Website.Core.Common.Infrastructure;

namespace Website.SPA
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

            // Setup logger
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Error()
                .WriteTo.MSSqlServer(Configuration.GetConnectionString("DefaultConnection"), "Logs")
                //, columnOptions: new Serilog.Sinks.MSSqlServer.ColumnOptions
                //{
                //    AdditionalDataColumns = new[]
                //    {
                //        new Serilog.Models.DataColumn { DataType = typeof(string), ColumnName = "Code" },
                //        new Serilog.Models.DataColumn { DataType = typeof(string), ColumnName = "CreatedBy" },
                //        new Serilog.Models.DataColumn { DataType = typeof(string), ColumnName = "WebsiteGuid" }
                //    }
                //})
                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            InitializerFactory.InitializeApplicationServices(Configuration, services);

            services.AddMvc();
        }

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            IInitializerFactory initializerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMiddleware<NonWwwRedirectMiddleware>();
            app.UseMiddleware<ErrorLoggingMiddleware>();
            //app.UseMiddleware<ApplicationContextMiddleware>();

            initializerFactory.InitializeApplicationDatabases(app.ApplicationServices);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}