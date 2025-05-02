using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio_Website.ViewComponents.LoginLayoutViewComponents
{
    public class _LoginLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

