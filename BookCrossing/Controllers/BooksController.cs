using BookCrossing.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookCrossing.Controllers
{
    public class BooksController: Controller
    {
        private readonly IBook _book;

        public BooksController(IBook book)
        {
            _book = book;
        }

        public ViewResult List()
        {
            var book = _book.Books;
            return View(book);
        }

    }
}
