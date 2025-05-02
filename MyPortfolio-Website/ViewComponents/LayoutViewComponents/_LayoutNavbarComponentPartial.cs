using Microsoft.AspNetCore.Mvc;
using MyPortfolio_Website.DAL.Context;

namespace MyPortfolio_Website.ViewComponents.LayoutViewComponents
{
    public class _LayoutNavbarComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {


            return View();
        }
    }
}
