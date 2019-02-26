using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.Application;
using Website.Common.ViewModels.AdminViewModels;
using Website.Models;

namespace Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class PageController : Controller
    {
        private readonly IWebsiteService _websiteService;
        private readonly IPageService _pageService;
        private readonly IContentService _contentService;

        public PageController(
            IWebsiteService websiteService,
            IPageService pageService,
            IContentService contentService)
        {
            _websiteService = websiteService;
            _pageService = pageService;
            _contentService = contentService;
        }

        public IActionResult Module(
                string page,
                int? id,
                bool newModule = false
            )
        {
            var selectedPage = _websiteService.GetPageBySlug(page);

            Content module = null;

            if (newModule)
            {
                module = new Content()
                {
                    PageId = selectedPage.Id
                };
            }
            else if (id.HasValue)
            {
                module = selectedPage.Content.FirstOrDefault(i => i.Id == id.Value);
            }

            var model = new ModuleViewModel()
            {
                Module = module,
                SelectedPage = selectedPage,
                isNewModule = newModule
            };

            ViewBag.Title = newModule ? "Modül Ekle" : "Modül Düzenle";

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PageOperation(ModuleViewModel model, string saveContent, string deleteContent)
        {
            if (!string.IsNullOrEmpty(saveContent))
            {
                if (!model.isNewModule)
                {
                    var page = _websiteService.GetPageBySlug(model.SelectedPage.SlugUrl);
                    await _contentService.Update(model.Module);
                }
                else
                {
                    await _contentService.Insert(model.Module);
                }

                return RedirectToAction("Index", "Page", new { Page = model.SelectedPage.SlugUrl });
            }
            else if (!string.IsNullOrEmpty(deleteContent))
            {
                await _contentService.Delete(model.Module);

                return RedirectToAction("Index", "Page", new { Page = model.SelectedPage.SlugUrl });
            }

            throw new Exception();
        }

        public async Task<IActionResult> Index(
                string page,
                string parentPage,
                int? contentId,
                bool newPage = false,
                bool main = false,
                bool other = false,
                bool? upDown = null
            )
        {
            if (upDown.HasValue)
            {
                if (!contentId.HasValue)
                    await MovePage(page, upDown.Value);
                else
                    await MoveContent(page, contentId.Value, upDown.Value);
                return Redirect(Request.Headers[HeaderNames.Referer].ToString());
            }

            var selectedPage = _websiteService.GetPageBySlug(page);

            if (newPage)
            {
                selectedPage = new Page()
                {
                    Content = new List<Content>(),
                    File = new List<File>(),
                    Childs = new List<Page>(),
                    Tag = new List<Tag>()
                };

                if (!string.IsNullOrWhiteSpace(parentPage))
                {
                    var parent = _websiteService.GetPageBySlug(parentPage);
                    selectedPage.Parent = parent;
                    selectedPage.ParentId = parent.Id;
                }
            }
            else if (main)
            {
                selectedPage = new Page()
                {
                    Childs = _websiteService.Menu().ToList()
                };
            }
            else if (other)
            {
                selectedPage = new Page()
                {
                    Childs = _websiteService.Pages().Where(i => i.Type <= 0).OrderBy(i => i.Priorty).ToList()
                };
            }

            var model = new AdminViewModel()
            {
                SelectedPage = selectedPage,
                Pages = _websiteService.Menu(),
                OtherPages = _websiteService.Pages().Where(i => i.Type <= 0).OrderBy(i => i.Priorty),
                SlugUrl = page,
                isNewPage = newPage,
                isMain = main,
                isOther = other
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Save(AdminViewModel model)
        {
            if (!model.isNewPage)
            {
                var page = _websiteService.GetPageBySlug(model.SelectedPage.OldSlugUrl);
                await _pageService.Update(page, model.SelectedPage);
            }
            else
            {
                await _pageService.Insert(model.SelectedPage);
            }

            return RedirectToAction("Index", "Page", new { Page = model.SelectedPage.SlugUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AdminViewModel model)
        {
            var selectedPage = _websiteService.GetPageBySlug(model.SelectedPage.OldSlugUrl);

            await _pageService.Delete(selectedPage);

            return RedirectToAction("Index", "Page");
        }

        private async Task MoveContent(string pageSlug, int contentId, bool isUp)
        {
            var page = _websiteService.GetPageBySlug(pageSlug);

            var i = 0;
            foreach (var item in page.Content)
            {
                if (item.Id == contentId)
                {
                    if (isUp)
                    {
                        item.Priorty = i - 3;
                    }
                    else
                    {
                        item.Priorty = i + 3;
                    }
                }
                else
                    item.Priorty = i;

                i += 2;
            }

            await _contentService.UpdatePriorty(page.Content);
        }

        private async Task MovePage(string pageSlug, bool isUp)
        {
            var page = _websiteService.GetPageBySlug(pageSlug);
            var siblingPages = page.Parent != null ? page.Parent.Childs : _websiteService.Menu();

            var i = 0;
            foreach (var item in siblingPages)
            {
                if (item == page)
                {
                    if (isUp)
                    {
                        item.Priorty = i - 3;
                    }
                    else
                    {
                        item.Priorty = i + 3;
                    }
                }
                else
                    item.Priorty = i;

                i += 2;
            }

            await _pageService.UpdatePriorty(siblingPages);
        }
    }
}