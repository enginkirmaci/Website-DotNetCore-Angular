using Microsoft.AspNetCore.Mvc;
using Website.Application;
using Website.Common.ViewModels;

namespace Views.Shared.Components.Footer
{
    public class Footer : ViewComponent
    {
        private readonly IWebsiteService _websiteService;

        public Footer(IWebsiteService websiteService)
        {
            _websiteService = websiteService;
        }

        public IViewComponentResult Invoke()
        {
            var model = new MasterViewModel()
            {
                Website = _websiteService.Website(),
                Settings = _websiteService.Settings(),
                Master = _websiteService.Master()
            };

            return View(model);
        }
    }
}