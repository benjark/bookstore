using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{

    public class BookstoreRepository : IBookStoreRepository

       
    {
        private BookStoreContext context { get; set; }

        public BookstoreRepository (BookStoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;
    }

}
