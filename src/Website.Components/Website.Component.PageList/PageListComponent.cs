using System.Linq;
using Website.Component.PageList.Entities;
using Website.Core.Application;
using Website.Core.Common.Entities;
using Website.Core.Common.Interfaces;
using Website.Core.System.Services;

namespace Website.Component.PageList
{
    public class PageListComponent : IPageComponent
    {
        private readonly ISystemService _systemService;
        private readonly IApplicationContext _applicationContext;

        public string Key { get; } = "pagelist";

        public PageListComponent(
            ISystemService systemService,
            IApplicationContext applicationContext)
        {
            _systemService = systemService;
            _applicationContext = applicationContext;
        }

        public ComponentOutput GetOutput(long id)
        {
            var page = _systemService.FindPage(id);
            var childs = _systemService.GetChildPages(page.Id).OrderByDescending(dto => dto.CreatedDate);

            return new PageListOutput
            {
                ShowTitle = id != _applicationContext.CurrentPage.Id,
                Page = page,
                Pages = childs
            };
        }
    }
}