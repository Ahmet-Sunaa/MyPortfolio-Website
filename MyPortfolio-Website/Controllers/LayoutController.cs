//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace WebApplication1.Controllers
//{
//    [Authorize(Roles = "Admin")]
//    public class LayoutController : Controller
//    {

//        public IActionResult Index()
//        {
//            return View();
//        }

//    }
//}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LayoutController : Controller
    {
        // Layout sayfasına yönlendirme
        public IActionResult Index()
        {
            return View();
        }

        // Çıkış işlemi
        public async Task<IActionResult> Logout()
        {
            // Kullanıcı oturumunu sonlandır
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Login sayfasına yönlendir
            return RedirectToAction("Index", "Login");
        }
    }
}
