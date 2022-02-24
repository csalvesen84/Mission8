using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CongoBasin.Models
{
    public class EFCongoBasinRepository : ICongoBasinRepository
    {

        private BookstoreContext context { get; set; }
        public EFCongoBasinRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;
    }
}
