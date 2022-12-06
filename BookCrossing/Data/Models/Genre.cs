using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Models
{
    public class Genre
    {
        public int Id { get; set; }

        public string GenreName { get; set; }

        public string Description { get; set; }

        public List<Book> Books { get; set; }
    }
}
