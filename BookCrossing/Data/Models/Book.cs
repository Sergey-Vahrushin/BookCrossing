using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        public int PublicationYear { get; set; }

        public string Publisher { get; set; }

        public string Img { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
