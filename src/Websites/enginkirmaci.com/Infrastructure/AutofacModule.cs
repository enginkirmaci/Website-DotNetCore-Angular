using Autofac;
using Common.Web.Data;
using Common.Web.Email;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using Website.Application;

namespace Infrastructure
{
    public class AutofacModule : Autofac.Module
    {
        public IConfiguration _configuration { get; }

        public AutofacModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(i => new SenGridEmailSender()
                .Configure(
                    _configuration["Email:SendGrid:Key"],
                    _configuration["Email:SendGrid:FromEmail"],
                    _configuration["Email:SendGrid:FromName"],
                    _configuration["Email:SendGrid:DefaultTemplate"]
                ))
                .As<IEmailSender>()
                .InstancePerLifetimeScope();

            builder.Register(i => new CachingEx(i.Resolve<IMemoryCache>())).As<ICachingEx>().SingleInstance();
            builder.Register(i => new SessionEx(i.Resolve<IHttpContextAccessor>())).As<ISessionEx>().SingleInstance();

            var websiteGuid = new Guid(_configuration["Settings:Website"]);

            builder.RegisterType<WebsiteService>().As<IWebsiteService>().OnActivated(i => i.Instance.Configure(websiteGuid));
            builder.RegisterType<PageService>().As<IPageService>().OnActivated(i => i.Instance.Configure(websiteGuid));
            builder.RegisterType<ContentService>().As<IContentService>().OnActivated(i => i.Instance.Configure(websiteGuid));
        }
    }
}