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
        private readonly IBooksGenre _booksGenres;


        public BooksController(IBook book, IBooksGenre booksGenre)
        {
            _book = book;
            _booksGenres = booksGenre;
        }

        [Route("Books/List")]
        [Route("Books/List/{genre?}")]
        public ViewResult List(int? genreId)
        {
            IEnumerable<Book> books;
            IEnumerable<Genre> genres;

            genres = _booksGenres.AllGenres.OrderBy(i => i.GenreName);

            ViewBag.Title = "Список книг";

            if (genreId != null)
            {
                books = _book.Books.Where(i => i.GenreId == genreId);
                ViewBag.Genre += "в жанре " + _booksGenres.AllGenres.FirstOrDefault(i => i.Id == genreId).GenreName;
            }
            else
            {
                books = _book.Books.OrderBy(i => i.Id);
            }
           
            var bookObj = new BookListViewModel
            {
                AllBooks = books,
                AllGenres = genres
            };

            ViewBag.BookCount = books.Count();

            return View(bookObj);
        }

    }
}
