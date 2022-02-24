using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CongoBasin.Infrastructure;
using CongoBasin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CongoBasin.Pages
{
    public class BuyModel : PageModel
    {
        private ICongoBasinRepository repo { get; set; }

        public BuyModel (ICongoBasinRepository temp)
        {
            repo = temp;
        }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookID, string returnUrl)
        {
            Book book = repo.Books.FirstOrDefault(x => x.BookId == bookID);



            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new { ReturnUrl = returnUrl});
        }
    }
}
