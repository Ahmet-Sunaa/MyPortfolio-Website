using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio_Website.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
