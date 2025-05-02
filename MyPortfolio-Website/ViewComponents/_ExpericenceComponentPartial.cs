using Microsoft.AspNetCore.Mvc;
using MyPortfolio_Website.DAL.Context;

namespace MyPortfolio_Website.ViewComponents
{
    public class _ExpericenceComponentPartial : ViewComponent
    {
        MyPortfolioDb HurdaciContext = new MyPortfolioDb();
        public IViewComponentResult Invoke()
        {
            var values = HurdaciContext.Expericences.ToList();
            return View(values);
        }
    }
}
