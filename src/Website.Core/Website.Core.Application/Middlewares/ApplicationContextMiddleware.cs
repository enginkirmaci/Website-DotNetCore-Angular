using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;
using Website.Core.System.Services;

namespace Website.Core.Application.Middlewares
{
    public class ApplicationContextMiddleware
    {
        private readonly RequestDelegate _next;

        public ApplicationContextMiddleware(
            RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context,
            ISystemService systemService,
            IApplicationContext applicationContext)
        {
            if (context.Request.Path.StartsWithSegments("/api"))
            {
                var url = context.Request.Headers[HeaderNames.Referer];
                var urlPaths = url.ToString().Replace($"{context.Request.Scheme}://{context.Request.Host}", string.Empty);

                //applicationContext.CurrentPage = systemService.FindPageFromUrl(urlPaths);
            }

            await _next(context);
        }
    }

    public static class HttpRequestExtensions
    {
        private const string RequestedWithHeader = "X-Requested-With";
        private const string XmlHttpRequest = "XMLHttpRequest";

        public static bool IsAjaxRequest(this HttpRequest request)
        {
            if (request.Headers != null)
            {
                return request.Headers[RequestedWithHeader] == XmlHttpRequest;
            }

            return false;
        }
    }
}