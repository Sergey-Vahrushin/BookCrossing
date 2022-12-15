using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Models
{
    public class IssueBookItem
    {
        public int Id { get; set; }

        public Book Book { get; set; }

        public string IssueBookId { get; set; }

    }
}
