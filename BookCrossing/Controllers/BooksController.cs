using BookCrossing.Data.Interfaces;
using BookCrossing.Data.Models;
using BookCrossing.ViewModels;
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

        [Route("Books/List")]
        [Route("Books/List/{genre?}")]
        public ViewResult List(string genre)
        {
            IEnumerable<Book> books;
            string currGenre = "";
            if (string.IsNullOrEmpty(genre))
            {
                books = _book.Books.OrderBy(i => i.Id);
            }
            else
            {
                books = _book.Books.Where(i => i.Genre.GenreName.Equals(genre));
                currGenre = genre;
            }
           
            var bookObj = new BookListViewModel
            {
                AllBooks = books,
                CurrGenre = currGenre
            };

            ViewBag.Title = "Список книг";
            return View(bookObj);
        }

    }
}
