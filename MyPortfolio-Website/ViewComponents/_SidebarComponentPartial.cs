using Microsoft.AspNetCore.Mvc;
using MyPortfolio_Website.DAL.Context;

namespace MyPortfolio_Website.ViewComponents
{
    public class _SidebarComponentPartial : ViewComponent
    {
        MyPortfolioDb HurdaciContext = new MyPortfolioDb();
        public IViewComponentResult Invoke()
        {
            var values = HurdaciContext.Personals.FirstOrDefault();
            return View(values);
        }
    }
}
