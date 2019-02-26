using Common.Utilities.Converters;
using Microsoft.AspNetCore.Mvc;
using Website.Application;
using Website.Common.ViewModels;

namespace Controllers
{
    public class StandartController : Controller
    {
        private readonly IWebsiteService _websiteService;
        private readonly IPageService _pageService;

        public StandartController(
            IWebsiteService websiteService,
            IPageService pageService)
        {
            _websiteService = websiteService;
            _pageService = pageService;
        }

        public IActionResult Index()
        {
            var slugUrl = UrlConverter.GetLastSegment(Request.Path);

            var page = _websiteService.GetPageBySlug(slugUrl);

            var model = new PageViewModel()
            {
                Page = page,
                ParentPage = page.Parent,
                SlugUrl = Request.Path.ToString() == "/" ? "home" : Request.Path.ToString()
            };

            ViewBag.Title = string.Format("{0} - {1}", model.Page.Title, _websiteService.Website().Name);

            return View(model);
        }
    }
}