using BookCrossing.Data.Interfaces;
using BookCrossing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Mocks
{
    public class MockBook : IBook
    {
        public IEnumerable<Book> Books
        {
            get
            {
                return new List<Book> {
                    new Book { Author = "Джоа Роулинг", Genre = "Фэнткзи", Name = "Гарри Поттер", PublicationYear = 2000, Publisher = "Москва"},
                    new Book { Author = "Толкиен", Genre = "Фэнтези", Name = "Властелин колец", PublicationYear = 1999, Publisher = "Питер"}
                };
            }
        }

        public Book GetBook(int bookID)
        {
            throw new NotImplementedException();
        }
    }
}
