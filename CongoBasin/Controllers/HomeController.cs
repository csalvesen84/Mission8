using CongoBasin.Models;
using CongoBasin.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongoBasin.Controllers
{
    public class HomeController : Controller
    {
        private ICongoBasinRepository repo;

        public HomeController (ICongoBasinRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string category, int pageNum = 1)
        {
            int pageSize = 10;

            var oneLiner = new BooksViewModel
            {
                Books = repo.Books.Where(x => x.Category == category || category == null).OrderBy(b => b.Title).Skip((pageNum - 1) * pageSize).Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBooks = (category == null ? repo.Books.Count(): repo.Books.Where(x => x.Category == category).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(oneLiner);
        }


    }
}
