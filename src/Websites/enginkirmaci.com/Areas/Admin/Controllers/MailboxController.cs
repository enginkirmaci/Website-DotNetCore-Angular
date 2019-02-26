using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class MailboxController : Controller
    {
        // GET: Admin/Mailbox
        public IActionResult Index()
        {
            return View();
        }
    }
}