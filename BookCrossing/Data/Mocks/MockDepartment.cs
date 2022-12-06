using BookCrossing.Data.Interfaces;
using BookCrossing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Mocks
{
    public class MockDepartment : IDepartment
    {
        public IEnumerable<Department> AllDepartments
        {
            get
            {
                return new List<Department>
                {
                    new Department{ City = "Нижний Новгород", Address = "Ул. Горького, д.134" },
                    new Department { City = "Москва", Address = "Ул. Саврасова, д.56" }
                };
            }
        }

        public Department GetObjectDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }
    }
}
