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
            if (!dbContent.Genre.Any())
            {
                dbContent.Genre.AddRange(Genres.Select(p => p.Value));
            }


            if (!dbContent.Book.Any())
            {
                dbContent.AddRange(
                    new Book
                    {
                        Author = "Джоа Роулинг",
                        Genre = Genres["Фэнтези"],
                        Name = "Гарри Поттер",
                        PublicationYear = 2000,
                        Publisher = "Москва"
                    },
                    new Book
                    {
                        Author = "Толкиен",
                        Genre = Genres["Фэнтези"],
                        Name = "Властелин колец",
                        PublicationYear = 1999,
                        Publisher = "Питер"
                    }
                );
            }

            if (!dbContent.Department.Any())
            {
                dbContent.AddRange(
                    new Department { City = "Нижний Новгород", Address = "Ул. Горького, д.134" },
                    new Department { City = "Москва", Address = "Ул. Саврасова, д.56" }
                );
            }
            dbContent.SaveChanges();
        }

        public static Dictionary<string, Genre> _Genre;

        public static Dictionary<string, Genre> Genres
        {
            get
            {
                if (_Genre == null)
                {
                    var list = new Genre[]
                    {
                        new Genre{ GenreName = "Фэнтези", Description = "Произведения жанра фэнтези основываются на мифологических и сказочных мотивах, переосмысленных или переработанных авторами."},
                        new Genre{ GenreName = "Ужасы", Description = " Авторы произведений в жанре «ужасы» создают жуткую и пугающую атмосферу. Ужас часто сверхъестественный, хотя может быть и не сверхъестественным"}
                    };

                    _Genre = new Dictionary<string, Genre>();
                    foreach (var el in list)
                    {
                        _Genre.Add(el.GenreName, el);
                    }
                }
                return _Genre;
            }
        }


    }
}
