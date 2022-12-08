using BookCrossing.Data.Mocks;
using BookCrossing.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent dbContent)
        {          

            if (!dbContent.Book.Any())
            {
                MockGenre _bookGenre = new MockGenre();

                dbContent.AddRange(
                    new Book
                    {
                        Author = "Джоа Роулинг",
                        Genre = _bookGenre.AllGenres.First(),
                        Name = "Гарри Поттер",
                        PublicationYear = 2000,
                        Publisher = "Москва"
                    },
                    new Book
                    {
                        Author = "Толкиен",
                        Genre = _bookGenre.AllGenres.Last(),
                        Name = "Властелин колец",
                        PublicationYear = 1999,
                        Publisher = "Питер"
                    }
                );

                dbContent.SaveChanges();
            }
        }

    }
}
