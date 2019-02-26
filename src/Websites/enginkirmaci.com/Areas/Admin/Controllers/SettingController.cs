using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Website.Application;
using Website.Common.ViewModels.AdminViewModels;

namespace Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SettingController : Controller
    {
        private readonly IWebsiteService _websiteService;

        public SettingController(
            IWebsiteService websiteService)
        {
            _websiteService = websiteService;
        }

        public async Task<IActionResult> Index(SettingViewModel model)
        {
            if (model?.Settings != null)
            {
                await _websiteService.UpdateSettings(model.Settings);
            }

            return View(new SettingViewModel()
            {
                Settings = _websiteService.Settings()
            });
        }
    }
}