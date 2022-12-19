using BookCrossing.Data.Interfaces;
using BookCrossing.Data.Models;
using BookCrossing.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Controllers
{
    public class OrderController: Controller
    {
        private readonly IAllOrder allOrders;

        private readonly IssueBook issueBook;
        private readonly IDepartment allDepartments;


        public OrderController(IAllOrder _appDBContent, IssueBook _issueBook, IDepartment _department)
        {
            allOrders = _appDBContent;
            issueBook = _issueBook;
            allDepartments = _department;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            IEnumerable<Department> departments;
            departments = allDepartments.AllDepartments;

            issueBook.ListIssueBookItems = issueBook.GetIssueItems();


            if (issueBook.ListIssueBookItems.Count == 0 )
            {
                ModelState.AddModelError("", "У вас должны быть товары");     
            }

            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            var orderCreateObj = new CheckoutViewModel
            {
                Order = order,
                AllDepartments = departments
            };

            return View(orderCreateObj);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Ваш заказ успешно обработан";
            return View();
        }
    }
}
