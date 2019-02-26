using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common.Web.ActionFilters;
using Common.Web.Middlewares;
using Common.Web.Resources;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Website.Models;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace enginkirmaci.com
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly ILogger Logger;

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
                .MinimumLevel.Verbose()
                .WriteTo.MSSqlServer(Configuration.GetConnectionString("DefaultConnection"), "Logs", LogEventLevel.Verbose, 50, null, null, true,
                new Serilog.Sinks.MSSqlServer.ColumnOptions()
                {
                    AdditionalDataColumns = new Serilog.Models.DataColumn[]
                    {
                        new Serilog.Models.DataColumn { DataType = typeof(string), ColumnName = "Code" },
                        new Serilog.Models.DataColumn { DataType = typeof(string), ColumnName = "CreatedBy" },
                        new Serilog.Models.DataColumn { DataType = typeof(string), ColumnName = "WebsiteGuid" }
                    }
                })
                .CreateLogger();

            Logger = new LoggerFactory()
                .AddSerilog()
                .CreateLogger<Program>();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebsiteDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Website.Models")));

            services.AddIdentity<WebsiteUser, IdentityRole>(i =>
            {
                i.Password.RequireDigit = false;
                i.Password.RequiredLength = 6;
                i.Password.RequireLowercase = false;
                i.Password.RequireNonAlphanumeric = false;
                i.Password.RequireUppercase = false;

                //i.SignIn.RequireConfirmedPhoneNumber = true;

                //i.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                //i.Lockout.MaxFailedAccessAttempts = 10;
            })
            .AddEntityFrameworkStores<WebsiteDbContext>()
            .AddDefaultTokenProviders()
            .AddErrorDescriber<TrIdentityErrorDescriber>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(o =>
            {
                o.LogoutPath = new PathString("/Admin/Account/LogOff");
                o.AccessDeniedPath = new PathString("/Admin/Account/Index");
                o.LoginPath = new PathString("/Admin/Account/Index");
            });

            //services.Configure<IdentityOptions>(options =>
            //{
            //    options.Cookies.ApplicationCookie.LoginPath = new PathString("/Admin/Account/Index");
            //    options.Cookies.ApplicationCookie.AccessDeniedPath = new PathString("/Admin/Account/Index");
            //    options.Cookies.ApplicationCookie.LogoutPath = new PathString("/Admin/Account/LogOff");
            //});

            services.AddMemoryCache();
            services.AddSession();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateAjaxAttribute));
            });

            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });

            services.AddSingleton(_ => Configuration);
            services.AddSingleton(_ => Logger);

            // Adds Autofac
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new AutofacModule(Configuration));
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMiddleware<NonWwwRedirectMiddleware>();
            app.UseMiddleware<ErrorLoggingMiddleware>();

            app.UseSession();

            var initializer = new WebsiteDbInitializer();
            initializer.InitializeDatabase(app.ApplicationServices);

            app.UseMvc(RouteConfig.RegisterRoutes);
        }
    }
}