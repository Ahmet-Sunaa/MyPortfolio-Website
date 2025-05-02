using Microsoft.AspNetCore.Mvc;
using MyPortfolio_Website.DAL.Context;

namespace MyPortfolio_Website.ViewComponents
{
    public class _PortfolioComponentPartial : ViewComponent
    {
        MyPortfolioDb HurdaciContext = new MyPortfolioDb();
        public IViewComponentResult Invoke()
        {
            var values = HurdaciContext.Portfolios.ToList();
            return View(values);
        }
    }
}
