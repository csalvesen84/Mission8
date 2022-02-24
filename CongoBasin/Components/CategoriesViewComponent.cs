using CongoBasin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongoBasin.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private ICongoBasinRepository repo { get; set; }

        public CategoriesViewComponent (ICongoBasinRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            var categories = repo.Books.Select(x => x.Category).Distinct().OrderBy(x => x);

            return View(categories);
        }
    }
}
