using BookCrossing.Data.Interfaces;
using BookCrossing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Repository
{
    public class DepartmentRepository: IDepartment
    {
        private readonly AppDBContent AppDBContent;

        public DepartmentRepository(AppDBContent _appDBContent)
        {
            AppDBContent = _appDBContent;
        }

        public IEnumerable<Department> AllDepartments => AppDBContent.Department;

        public Department GetObjectDepartment(int departmentId)
        {
            return AppDBContent.Department.FirstOrDefault(p => p.Id == departmentId);
        }
    }
}
