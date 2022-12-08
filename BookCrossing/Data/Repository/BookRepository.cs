using BookCrossing.Data.Interfaces;
using BookCrossing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Repository
{
    public class BookRepository : IBook
    {
        private  readonly AppDBContent AppDBContent;

        public BookRepository(AppDBContent _appDBContent)
        {
            AppDBContent = _appDBContent;
        }

        public IEnumerable<Book> Books => AppDBContent.Book;

        public Book GetObjectBook(int bookID)
        {
            return AppDBContent.Book.FirstOrDefault(p => p.Id == bookID);
        }
    }
}
