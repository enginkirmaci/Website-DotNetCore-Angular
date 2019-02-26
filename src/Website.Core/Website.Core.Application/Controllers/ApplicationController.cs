using Microsoft.AspNetCore.Mvc;
using Website.Core.System.Entities;
using Website.Core.System.Services;

namespace Website.Core.Application.Controllers
{
    [Route("api/[controller]")]
    public class ApplicationController : Controller
    {
        private readonly ISystemService _systemService;
        private readonly IPageBuilder _pageBuilder;

        public ApplicationController(
            ISystemService systemService,
            IPageBuilder pageBuilder)
        {
            _systemService = systemService;
            _pageBuilder = pageBuilder;
        }

        [HttpGet("[action]")]
        public JsonResult GetWebsite()
        {
            var model = new SystemOutput()
            {
                Website = _systemService.Website,
                Menu = _systemService.Menu,
                Settings = _systemService.Settings
            };

            return new JsonResult(model);
        }

        [HttpGet("[action]")]
        public JsonResult GetCurrentPage()
        {
            var page = _pageBuilder.GetCurrentPage();

            return new JsonResult(page);
        }
    }
}