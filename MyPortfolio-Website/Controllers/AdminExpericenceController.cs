using Microsoft.AspNetCore.Mvc;
using MyPortfolio_Website.DAL.Context;
using MyPortfolio_Website.DAL.Entities;

namespace MyPortfolio_Website.Controllers
{
    public class AdminExpericenceController : Controller
    {
        MyPortfolioDb context = new MyPortfolioDb();

        [HttpGet]
        public IActionResult Index()
        {
            var value = context.Expericences.ToList();
            return View(value);
        }
        public IActionResult DeleteExpericence(int id)
        {
            var value = context.Expericences.Find(id);
            context.Expericences.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateExpericence()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateExpericence(Expericence expericence)
        {
            context.Expericences.Add(expericence);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult UpdateExpericence(int id)
        {
            var expericence = context.Expericences.FirstOrDefault(e => e.ExpericenceId == id);

            if (expericence == null)
            {
                return NotFound();
            }

            return View(expericence);
        }
        [HttpPost]
        public IActionResult UpdateExpericenceAjax(Expericence expericence)
        {

            Console.WriteLine(expericence.ExpericenceId);

            var dbSkill = context.Expericences.FirstOrDefault(e => e.ExpericenceId == expericence.ExpericenceId);
            if (dbSkill != null)
            {
                dbSkill.Title = expericence.Title;
                dbSkill.ExpericenceRole = expericence.ExpericenceRole;
                dbSkill.ExpericenceDate = expericence.ExpericenceDate;
                dbSkill.ExpericenceDesc = expericence.ExpericenceDesc;
                
                context.SaveChanges();

                return Json(new { success = true, message = "Expericence updated successfully!" });
            }
            else
            {
                return Json(new { success = false, message = "Expericence not found!" });
            }
        }
    }
}
