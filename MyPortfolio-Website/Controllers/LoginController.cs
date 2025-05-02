using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MyPortfolio_Website.DAL.Context;
using MyPortfolio_Website.DAL.Entities;
using WebApplication1.Utilities;
using MyPortfolio_Website.DAL.ViewModel;


namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyPortfolioDb context = new MyPortfolioDb();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> LoginAdminAjax(User model)
        {

            if (model.UserName!=null && model.Password!=null)
            {
                var admin = context.Users.FirstOrDefault(a => a.UserName == model.UserName);

                if (admin != null && PasswordHelper.VerifyPassword(model.Password, admin.PasswordHash, admin.Salt))
                {
                    // Kullanıcı giriş bilgileri doğru, oturum başlat
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, admin.UserName),
                        new Claim(ClaimTypes.Role, "Admin") // Rol ekleniyor
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    return Json(new { success = true, redirectUrl = Url.Action("Index", "Admin") });
                }
                else
                {
                    return Json(new { success = false, message = "Kullanıcı adı ya da şifre yanlış" });
                }
            }
            return Json(new { success = false, message = "Eksik bilgi"});

        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var admin = context.Users.FirstOrDefault(a => a.Email == email);
            EmailSender _emailSender = new EmailSender();
            if (admin == null)
            {
                ViewBag.ErrorMessage = "Bu e-posta adresiyle kayıtlı bir admin bulunamadı.";
                return View();
            }

            // Token oluşturuluyor
            var token = Guid.NewGuid().ToString();
            var tokenExpiry = DateTime.UtcNow.AddHours(1);  // Token'ın geçerliliği 1 saat

            // Veritabanındaki admin kaydına token ve geçerlilik süresi ekleniyor
            admin.ResetToken = token;
            admin.TokenExpiry = tokenExpiry;
            await context.SaveChangesAsync();

            // Şifre sıfırlama linki oluşturuluyor
            var resetLink = Url.Action("ResetPassword", "Login", new { token = token }, Request.Scheme);

            // E-posta gönderimi
            string subject = "Şifre Sıfırlama Linki";
            string body = $"Şifrenizi sıfırlamak için <a href=\"{resetLink}\">buraya tıklayın</a>";
            await _emailSender.SendEmailAsync(email, subject, body);

            return View("ForgotPasswordConfirmation");
        }



        [HttpGet]
        [Route("Login/ResetPassword")]
        public IActionResult ResetPassword(string token)
        {
            // Token doğrulama işlemi
            var admin = context.Users.FirstOrDefault(a => a.ResetToken == token);

            if (admin == null || admin.TokenExpiry < DateTime.UtcNow)
            {
                return View("ResetPasswordFailed");  // Geçersiz token veya süresi dolmuş
            }

            return View(new ResetPasswordViewModel { Token = token });
        }


        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {

            if (model.NewPassword!=null)
            {

                var admin = context.Users.FirstOrDefault(a => a.ResetToken == model.Token);
                if (admin != null && admin.TokenExpiry > DateTime.UtcNow)
                {
                    var (passwordHash, salt) = PasswordHelper.HashPassword(model.NewPassword);
                    admin.PasswordHash = passwordHash;
                    admin.Salt = salt;
                    admin.ResetToken = null;  // Token sıfırlanıyor
                    admin.TokenExpiry = null;  // Token süresi sıfırlanıyor

                    await context.SaveChangesAsync();
                    return RedirectToAction("index", "Login");
                }
            }
            return View(model);
        }
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

    }
}
