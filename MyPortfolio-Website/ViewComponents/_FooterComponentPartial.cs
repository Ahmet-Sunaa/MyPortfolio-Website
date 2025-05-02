using Microsoft.AspNetCore.Mvc;
using MyPortfolio_Website.DAL.Context;

namespace MyPortfolio_Website.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        MyPortfolioDb HurdaciContext = new MyPortfolioDb();
        public IViewComponentResult Invoke()
        {
            var values = HurdaciContext.Personals.First();
            return View(values);
        }
    }
}
