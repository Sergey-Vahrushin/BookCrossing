using BookCrossing.Data.Interfaces;
using BookCrossing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Repository
{
    public class GenreRepository : IBooksGenre
    {
        private readonly AppDBContent appDBContent;

        public GenreRepository(AppDBContent _appDBContent)
        {
            appDBContent = _appDBContent;
        }

        public IEnumerable<Genre> AllGenres => appDBContent.Genre;
    }
}
