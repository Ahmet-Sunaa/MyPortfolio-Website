using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio_Website.DAL.Context;
using MyPortfolio_Website.DAL.Entities;

namespace MyPortfolio_Website.Controllers
{
    public class AdminPersonalsController : Controller
    {
        MyPortfolioDb context = new MyPortfolioDb();
        public IActionResult Index()
        {
            var values = context.Personals.FirstOrDefault();
            if (values == null)
            {
                var personal = new Personal
                {
                    PersonalLinkedin = "https://www.linkedin.com/in/yourprofile",
                    PersonalCv = "https://www.yourcv.com",
                    PersonalGithub = "https://www.github.com/in/yourprofile",
                    PersonalName = "Your Name",
                    PersonalPhone = "1234567890",
                    PersonalImage = "https://www.yourimage.com",
                    PersonalPosition = "Your Position"
                };

                context.Personals.Add(personal);
                context.SaveChanges();
                return View(personal);
            }
            return View(values);
        }

        [HttpPost]
        public IActionResult updatePersonalAjax([FromBody] Personal model)
        {
            var personal = context.Personals.FirstOrDefault(p => p.PersonalId == model.PersonalId);
            if (personal == null)
                return Json(new { success = false, message = "Kayıt bulunamadı." });

            personal.PersonalName = model.PersonalName;
            personal.PersonalPosition = model.PersonalPosition;
            personal.PersonalLinkedin = model.PersonalLinkedin;
            personal.PersonalGithub = model.PersonalGithub;
            personal.PersonalPhone = model.PersonalPhone;
            personal.PersonalCv = model.PersonalCv;
            personal.PersonalImage = model.PersonalImage;

            context.SaveChanges();

            return Json(new { success = true, message = "Başarıyla güncellendi." });
        }
    }
}
