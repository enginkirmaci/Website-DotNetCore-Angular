using Microsoft.AspNetCore.Mvc;
using Website.Application;
using Website.Common.ViewModels;

namespace Views.Shared.Components.Header
{
    public class Header : ViewComponent
    {
        private readonly IWebsiteService _websiteService;

        public Header(IWebsiteService websiteService)
        {
            _websiteService = websiteService;
        }

        public IViewComponentResult Invoke()
        {
            var slugUrl = Request.Path.ToString() == "/" ? "home" : Request.Path.ToString();

            var model = new MasterViewModel()
            {
                Website = _websiteService.Website(),
                Menu = _websiteService.Menu(),
                SlugUrl = slugUrl,
                Settings = _websiteService.Settings()
            };

            return View(model);
        }
    }
}