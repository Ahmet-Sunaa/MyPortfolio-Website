using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MyPortfolio_Website.DAL.Context;
using MyPortfolio_Website.DAL.Entities;

namespace MyPortfolio_Website.Controllers
{
    public class AdminAboutController : Controller
    {
        MyPortfolioDb context = new MyPortfolioDb();
        [HttpGet]
        public IActionResult Index()
        {
            var abouts = context.Abouts.ToList();

            if (abouts.Count == 0) {
                var about = new About
                {
                    Title = "Default Title",
                    Description = "Default Description",
                    Name = "Default Name",
                    NameDesc = "Default NameDesc",
                    Degree = "Default Degree",
                    DegreeDesc = "Default DegreeDesc",
                    Phone = "Default Phone",
                    PhoneDesc = "Default PhoneDesc",
                    Adress = "Default Adress",
                    AdressDesc = "Default AdressDesc",
                    Birthday = "Default Birthday",
                    Birthdaydesc = "Default Birthdaydesc",
                    Experience = "Default Experience",
                    ExperienceDesc = "Default ExperienceDesc",
                    Email = "Default Email",
                    EmailDesc = "Default EmailDesc",
                    Freelance = "Default Freelance",
                    FreelanceDesc = "Default FreelanceDesc",
                    SubArea1 = "Default SubArea1",
                    SubArea2 = "Default SubArea2",
                    SubArea3 = "Default SubArea3",
                    SubArea4 = "Default SubArea4",
                    SubArea5 = "Default SubArea5",
                    SubArea6 = "Default SubArea6"
                };
                context.Abouts.Add(about);
                context.SaveChanges();
                abouts.Add(about);

                var aboutEn = new About
                {
                    Title = "Default Title",
                    Description = "Default Description",
                    Name = "Default Name",
                    NameDesc = "Default NameDesc",
                    Degree = "Default Degree",
                    DegreeDesc = "Default DegreeDesc",
                    Phone = "Default Phone",
                    PhoneDesc = "Default PhoneDesc",
                    Adress = "Default Adress",
                    AdressDesc = "Default AdressDesc",
                    Birthday = "Default Birthday",
                    Birthdaydesc = "Default Birthdaydesc",
                    Experience = "Default Experience",
                    ExperienceDesc = "Default ExperienceDesc",
                    Email = "Default Email",
                    EmailDesc = "Default EmailDesc",
                    Freelance = "Default Freelance",
                    FreelanceDesc = "Default FreelanceDesc",
                    SubArea1 = "Default SubArea1",
                    SubArea2 = "Default SubArea2",
                    SubArea3 = "Default SubArea3",
                    SubArea4 = "Default SubArea4",
                    SubArea5 = "Default SubArea5",
                    SubArea6 = "Default SubArea6"
                };
                context.Abouts.Add(aboutEn);
                context.SaveChanges();
                abouts.Add(aboutEn);
            }            
            
            return View(abouts);
        }
        
        public JsonResult UpdateAboutAjax([FromBody] About about)
        {

            var existingAbouts = context.Abouts.ToList();


            if (existingAbouts != null && existingAbouts[0].AboutId.Equals(about.AboutId))
            {
                var existingAbout = existingAbouts[0];
                existingAbout.Title = about.Title;
                existingAbout.Description = about.Description;
                existingAbout.Name = about.Name;
                existingAbout.NameDesc = about.NameDesc;
                existingAbout.Degree = about.Degree;
                existingAbout.DegreeDesc = about.DegreeDesc;
                existingAbout.Phone = about.Phone;
                existingAbout.PhoneDesc = about.PhoneDesc;
                existingAbout.Adress = about.Adress;
                existingAbout.AdressDesc = about.AdressDesc;
                existingAbout.Birthday = about.Birthday;
                existingAbout.Birthdaydesc = about.Birthdaydesc;
                existingAbout.Experience = about.Experience;
                existingAbout.ExperienceDesc = about.ExperienceDesc;
                existingAbout.Email = about.Email;
                existingAbout.EmailDesc = about.EmailDesc;
                existingAbout.Freelance = about.Freelance;
                existingAbout.FreelanceDesc = about.FreelanceDesc;
                existingAbout.SubArea1 = about.SubArea1;
                existingAbout.SubArea2 = about.SubArea2;
                existingAbout.SubArea3 = about.SubArea3;
                existingAbout.SubArea4 = about.SubArea4;
                existingAbout.SubArea5 = about.SubArea5;
                existingAbout.SubArea6 = about.SubArea6;
                existingAbouts[0] = existingAbout;
                context.SaveChanges();

                return Json(new { success = true, message = "Data updated successfully!" });
            }

            return Json(new { success = false, message = "Update failed! Record not found." });
        }

    }
}
