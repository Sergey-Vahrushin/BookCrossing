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
        public IEnumerable<Book> Books => throw new NotImplementedException();

        public Book GetObjectBook(int bookID)
        {
            throw new NotImplementedException();
        }
    }
}
