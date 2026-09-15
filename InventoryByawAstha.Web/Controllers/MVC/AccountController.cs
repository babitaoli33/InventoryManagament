using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryByawAstha.Web.Controllers.MVC
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("InventoryCookie");

            return RedirectToAction(
                "Login",
                "Account"
            );
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}