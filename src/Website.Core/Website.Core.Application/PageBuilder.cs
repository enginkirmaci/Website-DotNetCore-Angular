using System.Collections.Generic;
using System.Linq;
using Website.Core.Common.Dtos;
using Website.Core.Common.Interfaces;
using Website.Core.System.Services;

namespace Website.Core.Application
{
    public class PageBuilder : IPageBuilder
    {
        private readonly ISystemService _systemService;
        private readonly IApplicationContext _context;
        private readonly IEnumerable<IPageComponent> _pageComponents;
        private readonly ICacheService _cacheService;

        public PageBuilder(
            ISystemService systemService,
            IApplicationContext context,
            IEnumerable<IPageComponent> pageComponents,
            ICacheService cacheService)
        {
            _systemService = systemService;
            _context = context;
            _pageComponents = pageComponents;
            _cacheService = cacheService;
        }

        public PageDto GetCurrentPage()
        {
            return FindPage(_context.CurrentPage?.Id);
        }

        public PageDto FindPage(long? pageId)
        {
            if (!_cacheService.Exists<PageDto>(pageId.ToString()))
            {
                var page = _systemService.FindPage(pageId);

                foreach (var component in page.Components)
                {
                    var builder = _pageComponents.FirstOrDefault(i => i.Key == component.Key);
                    if (builder != null)
                    {
                        component.Output = builder.GetOutput(component.RelatedId);
                    }
                }

                _cacheService.Add(pageId.ToString(), page);
            }

            return _cacheService.Get<PageDto>(pageId.ToString());
        }
    }
}