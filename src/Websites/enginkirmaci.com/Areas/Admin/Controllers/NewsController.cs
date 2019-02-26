using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class NewsController : Controller
    {
        //private readonly IWebsiteService _websiteService;
        //private readonly IPageService _pageService;

        //public NewsController(
        //    IWebsiteService websiteService,
        //    IPageService pageService)
        //{
        //    _websiteService = websiteService;
        //    _pageService = pageService;
        //}

        //public IActionResult Index()
        //{
        //    var model = new NewsModel()
        //    {
        //        News = _websiteService.Pages().OrderByDescending(i => i.CreatedDate)
        //    };

        //    return View(model);
        //}

        //public IActionResult Edit(
        //        string page,
        //        bool newPage = false
        //    )
        //{
        //    var selectedPage = _websiteService.GetPageBySlug(page);

        //    if (newPage)
        //    {
        //        selectedPage = new Page();
        //        selectedPage.Content = new List<Content>();
        //        selectedPage.File = new List<File>();
        //        selectedPage.Childs = new List<Page>();
        //        selectedPage.Tag = new List<Tag>();
        //    }

        //    var model = new NewsModel()
        //    {
        //        SelectedPage = selectedPage,
        //        isNew = newPage
        //    };

        //    ViewBag.Title = newPage ? "Haber Ekle" : "Haber Düzenle";

        //    return View(model);
        //}

        //[HttpPost]
        //public IActionResult Save(AdminPageModel model)
        //{
        //    if (!model.isNewPage)
        //    {
        //        var page = _websiteService.GetPageBySlug(model.SelectedPage.OldSlugUrl);
        //        _pageService.Update(page, model.SelectedPage);
        //    }
        //    else
        //    {
        //        _pageService.Insert(model.SelectedPage);
        //    }

        //    return RedirectToAction("Index", "Page", new { Page = model.SelectedPage.SlugUrl });
        //}
    }
}