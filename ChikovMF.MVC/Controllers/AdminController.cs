using ChikovMF.Application.Services.AdminService;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChikovMF.MVC.Controllers
{
    public class AdminController : BaseController
    {
        [HttpGet("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginPost(string password)
        {
            if (ModelState.IsValid)
            {
                var result = _adminService.IsValidPassword(password);

                if (result)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, "Admin"),
                        //new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
                    };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Неверный пароль");
            }
            return View("Login");
        }

        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
    }
}
