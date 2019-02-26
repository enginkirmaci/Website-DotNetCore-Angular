using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Website.Areas.Admin
{
    public class AdminAreaRegistration
    {
        public static void RegisterArea(IRouteBuilder routes)
        {
            routes.MapRoute(
                name: "Admin_default",
                template: "Admin/{controller}/{action}/{id?}"
            );
        }
    }
}