using BookCrossing.Data.Interfaces;
using BookCrossing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Mocks
{
    public class MockGenre : IBooksGenre
    {
        public IEnumerable<Genre> AllGenres
        {
            get
            {
                return new List<Genre>
                {
                    new Genre{ GenreName = "Фэнтези", Description = "Произведения жанра фэнтези основываются на мифологических и сказочных мотивах, переосмысленных или переработанных авторами."},
                    new Genre{ GenreName = "Ужасы", Description = " Авторы произведений в жанре «ужасы» создают жуткую и пугающую атмосферу. Ужас часто сверхъестественный, хотя может быть и не сверхъестественным"}
                };
            }
        }
    }
}
