using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Website.Common.AccountViewModels;
using Website.Models;

namespace Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly UserManager<WebsiteUser> _userManager;
        private readonly SignInManager<WebsiteUser> _signInManager;

        public AccountController(
            IHttpContextAccessor httpContextAccessor,
            UserManager<WebsiteUser> userManager,
            SignInManager<WebsiteUser> signInManager
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (_signInManager.IsSignedIn(User))
            {
                _session.Remove("LOGGED_USER" + _userManager.GetUserId(User));
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }

                ModelState.AddModelError(string.Empty, "E-mail adresiniz veya şifreniz hatalı.");
                return View(model);
            }

            return View(model);
        }

        public async Task<IActionResult> NewUser()
        {
            var user = new WebsiteUser
            {
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                TwoFactorEnabled = false,
                PhoneNumberConfirmed = false,
                LockoutEnabled = false
            };

            var result = await _userManager.CreateAsync(user, "admin123");

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOff()
        {
            _session.Remove("LOGGED_USER" + _userManager.GetUserId(User));
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}