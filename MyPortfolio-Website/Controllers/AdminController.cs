using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio_Website.DAL.Context;
using MyPortfolio_Website.DAL.Entities;
using MyPortfolio_Website.DAL.ViewModel;
using WebApplication1.Utilities;

namespace MyPortfolio_Website.Controllers
{
   [Authorize(Roles = "Admin")]  // Sadece "Admin" rolüne sahip kullanıcılar erişebilir
    public class AdminController : Controller
    {

        MyPortfolioDb context = new MyPortfolioDb();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult UpdateAdmin()
        {
            var admin = context.Users.FirstOrDefault();
            return View(admin);
        }
        [HttpPost]
        public JsonResult UpdateAdminAjax([FromBody] User admin)
        {
            var existingAdmin = context.Users.FirstOrDefault();

            if (existingAdmin != null)
            {
                // Kullanıcı adı güncellemesi
                existingAdmin.UserName = admin.UserName;
                existingAdmin.Email = admin.Email;
                // Yeni şifre verildiyse hashleme
                if (!string.IsNullOrEmpty(admin.Password))
                {
                    var (passwordHash, salt) = PasswordHelper.HashPassword(admin.Password);
                    existingAdmin.PasswordHash = passwordHash;
                    existingAdmin.Salt = salt;
                }

                context.SaveChanges();

                return Json(new { success = true, message = "Admin bilgisi başarıyla güncellendi." });
            }

            return Json(new { success = false, message = "Güncelleme başarısız. Kayıt bulunamadı." });
        }

        


    }
}
