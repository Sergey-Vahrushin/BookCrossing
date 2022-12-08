using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCrossing.Data.Interfaces;
using BookCrossing.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookCrossing.Controllers
{
    public class DepartmentsController: Controller
    {
        private readonly IDepartment _department;

        public DepartmentsController(IDepartment department)
        {
            _department = department;
        }

        public ViewResult List()
        {
            ViewBag.Title = "Список пунктов выдачи";
            DepartmentListViewModel obj = new DepartmentListViewModel();
            var departments = _department.AllDepartments;
            return View(departments);
        }

    }
}
