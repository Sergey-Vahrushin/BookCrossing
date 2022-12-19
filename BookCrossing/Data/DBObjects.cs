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
                        Author = "Джоан Роулинг",
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
                    },
                    new Book
                    {
                        Author = "Джейн Остин",
                        Genre = Genres["Роман"],
                        Name = "Гордость и предубеждение",
                        PublicationYear = 2000,
                        Publisher = "Москва"
                    },
                    new Book
                    {
                        Author = "Филип Пулман",
                        Genre = Genres["Фантастика"],
                        Name = "Тёмные начала",
                        PublicationYear = 1990,
                        Publisher = "Буква"
                    },
                    new Book
                    {
                        Author = "Клайв Стэйплз Льюис",
                        Genre = Genres["Фэнтези"],
                        Name = "Лев, колдунья и платяной шкаф",
                        PublicationYear = 1999,
                        Publisher = "Буква"
                    },
                    new Book
                    {
                        Author = "Джордж Оруэлл",
                        Genre = Genres["Фантастика"],
                        Name = "1984",
                        PublicationYear = 1999,
                        Publisher = "Буква"
                    },
                    new Book
                    {
                        Author = "Маргарет Митчелл",
                        Genre = Genres["Роман"],
                        Name = "Унесённые ветром",
                        PublicationYear = 1993,
                        Publisher = "Буква"
                    },
                    new Book
                    {
                        Author = "Николай Гоголь",
                        Genre = Genres["Ужасы"],
                        Name = "Вий",
                        PublicationYear = 1993,
                        Publisher = "Буква"
                    },
                    new Book
                    {
                        Author = "Льюис Кэррол",
                        Genre = Genres["Сказки"],
                        Name = "Алиса в Стране чудес",
                        PublicationYear = 1993,
                        Publisher = "Буква"
                    },
                    new Book
                    {
                        Author = "Брэм Стокер",
                        Genre = Genres["Сказки"],
                        Name = "Дракула",
                        PublicationYear = 1996,
                        Publisher = "Москва"
                    }

                );
            }

            if (!dbContent.Department.Any())
            {
                dbContent.AddRange(
                    new Department
                    {
                        City = "Нижний Новгород",
                        Address = "Ул. Горького, д.134",
                        EndTime = Convert.ToDateTime("2010-12-25 20:00:00"),
                        StartTime = Convert.ToDateTime("2010-12-25 08:00:00")
                    },
                    new Department
                    {
                        City = "Москва",
                        Address = "Ул. Саврасова, д.56",
                        EndTime = Convert.ToDateTime("2010-12-25 21:00:00"),
                        StartTime = Convert.ToDateTime("2010-12-25 09:00:00")
                    }
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
                        new Genre{ GenreName = "Ужасы", Description = " Авторы произведений в жанре «ужасы» создают жуткую и пугающую атмосферу. Ужас часто сверхъестественный, хотя может быть и не сверхъестественным"},
                        new Genre{ GenreName = "Детективы", Description = " литературный и кинематографический жанр, описывающий процесс исследования загадочного происшествия с целью выяснения его обстоятельств и раскрытия загадки."},
                        new Genre{ GenreName = "Фантастика", Description = " жанр, объединяющий художественные произведения, в которых повествуется о событиях, мирах и героях, нарушающих границы реальности. Фантастика рассказывает о том, что находится за гранью реальности, и строится на фантастическом допущении"},
                        new Genre{ GenreName = "Роман", Description = " жанр, объединяющий художественные произведения, в которых повествуется о событиях, мирах и героях, нарушающих границы реальности. Фантастика рассказывает о том, что находится за гранью реальности, и строится на фантастическом допущении"},
                        new Genre{ GenreName = "Сказки", Description = " Эпическое, преимущественно прозаическое произведение с волшебным, героическим или бытовым сюжетом. Сказку характеризует отсутствие претензий на историчность повествования, нескрываемая вымышленность сюжета."}
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
