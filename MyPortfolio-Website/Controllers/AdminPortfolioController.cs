using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio_Website.DAL.Context;
using MyPortfolio_Website.DAL.Entities;

namespace MyPortfolio_Website.Controllers
{
    public class AdminPortfolioController : Controller
    {
        MyPortfolioDb context = new MyPortfolioDb();

        [HttpGet]
        public IActionResult Index()
        {
            var value = context.Portfolios.ToList();
            return View(value);
        }

        public IActionResult DeleteSkill(int id)
        {
            var value = context.Portfolios.Find(id);
            context.Portfolios.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CreatePortfolio()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePortfolio(string Title, string PortfolioName, string PortfolioDesc,
    string PortfolioCategories, string PortfolioUrl, string PortfolioWebUrl, IFormFile PortfolioImage)
        {
            string base64Image = null;



            if (PortfolioImage != null && PortfolioImage.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await PortfolioImage.CopyToAsync(memoryStream);
                    var imageBytes = memoryStream.ToArray();
                    base64Image = Convert.ToBase64String(imageBytes);
                    Console.WriteLine(base64Image);
                }
            }else
            {
                base64Image = "";
            }

            var newPortfolio = new Portfolio
            {
                Title = Title,
                PortfolioName = PortfolioName,
                PortfolioDesc = PortfolioDesc,
                PortfolioCategories = PortfolioCategories,
                PortfolioUrl = PortfolioUrl,
                PortfolioWebUrl = PortfolioWebUrl,
                PortfolioImage = base64Image
            };

            context.Portfolios.Add(newPortfolio);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdatePortfolio(int id)
        {
            var skill = context.Portfolios.FirstOrDefault(e => e.PortfolioId == id);

            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePortfolio(int Id, string Title, string PortfolioName,
                                                        string PortfolioDesc, string PortfolioCategories, string PortfolioUrl, string PortfolioWebUrl,
                                                        string OldImage, IFormFile NewImage)
        {
            var portfolio = await context.Portfolios.FindAsync(Id);
            if (portfolio == null) return NotFound();

            portfolio.Title = Title;
            portfolio.PortfolioName = PortfolioName;
            portfolio.PortfolioDesc = PortfolioDesc;
            portfolio.PortfolioCategories = PortfolioCategories;
            portfolio.PortfolioUrl = PortfolioUrl;
            portfolio.PortfolioWebUrl = PortfolioWebUrl;


            if (NewImage != null && NewImage.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await NewImage.CopyToAsync(memoryStream);
                    var imageBytes = memoryStream.ToArray();
                    portfolio.PortfolioImage = Convert.ToBase64String(imageBytes);
                }
            }
            else
            {
                portfolio.PortfolioImage = OldImage; // Yeni resim yoksa eskisini koru
            }

            context.Portfolios.Update(portfolio);
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
