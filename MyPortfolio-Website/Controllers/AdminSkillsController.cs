using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio_Website.DAL.Context;
using MyPortfolio_Website.DAL.Entities;

namespace MyPortfolio_Website.Controllers
{
    public class AdminSkillsController : Controller
    {
        MyPortfolioDb context = new MyPortfolioDb();

        [HttpGet]
        public IActionResult Index()
        {
            var value = context.Skills.ToList();
            return View(value);
        }

        public IActionResult DeleteSkill(int id)
        {
            var value = context.Skills.Find(id);
            context.Skills.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            Console.WriteLine(skill);
            context.Skills.Add(skill);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var skill = context.Skills.FirstOrDefault(e => e.SkillId == id);

            if (skill == null)
            {
                return NotFound();  
            }

            return View(skill);
        }
        [HttpPost]
        public IActionResult UpdateSkillAjax(Skill skill)
        {


            var dbSkill = context.Skills.FirstOrDefault(e => e.SkillId == skill.SkillId);
            if (dbSkill != null)
            {
                dbSkill.Title = skill.Title;
                dbSkill.SkillName = skill.SkillName;
                dbSkill.SkillPoint = skill.SkillPoint;

                context.SaveChanges();

                return Json(new { success = true, message = "Skill updated successfully!" });
            }
            else
            {
                return Json(new { success = false, message = "Skill not found!" });
            }
        }
    }
}
