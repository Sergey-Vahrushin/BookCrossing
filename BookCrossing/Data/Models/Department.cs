using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string City { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string Address { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
