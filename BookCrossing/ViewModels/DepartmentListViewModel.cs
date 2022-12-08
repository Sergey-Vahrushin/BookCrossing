using BookCrossing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.ViewModels
{
    public class DepartmentListViewModel
    {
        public IEnumerable<Department> AllDepartments { get; }
    }
}
