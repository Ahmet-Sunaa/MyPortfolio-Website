﻿using Microsoft.AspNetCore.Mvc;
using MyPortfolio_Website.DAL.Context;

namespace MyPortfolio_Website.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        MyPortfolioDb HurdaciContext = new MyPortfolioDb();
        public IViewComponentResult Invoke()
        {
            //var values = HurdaciContext.Abouts.ToList();
            var values = HurdaciContext.Abouts.First();
            return View(values);
        }
    }
}
