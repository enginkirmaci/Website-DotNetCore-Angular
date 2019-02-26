using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Infrastructure
{
    public class RouteConfig
    {
        public static void RegisterRoutes(IRouteBuilder routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");

            routes.MapRoute(
                name: "error",
                template: "hata/{id?}",
                defaults: new
                {
                    controller = "Error",
                    action = "Index"
                });

            routes.MapRoute(
                name: "Standart",
                template: "{*anything}",
                defaults: new
                {
                    controller = "Standart",
                    action = "Index"
                }
            );

            //AdminAreaRegistration.RegisterArea(routes);
        }
    }
}