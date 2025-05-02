using Microsoft.AspNetCore.Mvc;
using MyPortfolio_Website.DAL.Context;

namespace MyPortfolio_Website.ViewComponents
{
    public class _SkillComponentPartial : ViewComponent
    {
        MyPortfolioDb HurdaciContext = new MyPortfolioDb();
        public IViewComponentResult Invoke()
        {
            var values = HurdaciContext.Skills.ToList();
            return View(values);
        }
    }
}
