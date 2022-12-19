using BookCrossing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.ViewModels
{
    public class CheckoutViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<Department> AllDepartments { get; set; }
    }
}
