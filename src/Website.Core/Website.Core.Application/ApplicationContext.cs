using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using Website.Core.Common.Dtos;
using Website.Core.System.Services;

namespace Website.Core.Application
{
    public class ApplicationContext : IApplicationContext
    {
        private readonly ISystemService _systemService;
        private readonly IHttpContextAccessor _contextAccessor;

        public ApplicationContext(
            ISystemService systemService,
            IHttpContextAccessor contextAccessor)
        {
            _systemService = systemService;
            _contextAccessor = contextAccessor;
        }

        private WebsiteDto _website;
        private PageDto _currentPage;

        public PageDto CurrentPage
        {
            get
            {
                if (_currentPage == null && _contextAccessor.HttpContext.Request.Path.StartsWithSegments("/api"))
                {
                    var url = _contextAccessor.HttpContext.Request.Headers[HeaderNames.Referer];
                    var urlPaths = url.ToString().Replace(
                        $"{_contextAccessor.HttpContext.Request.Scheme}://{_contextAccessor.HttpContext.Request.Host}",
                        string.Empty);

                    _currentPage = _systemService.FindPage(urlPaths);
                }

                return _currentPage;
            }
        }

        public WebsiteDto Website => _website ?? (_website = _systemService.Website);
    }
}