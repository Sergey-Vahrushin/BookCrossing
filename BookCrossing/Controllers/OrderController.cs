using BookCrossing.Data.Interfaces;
using BookCrossing.Data.Models;
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

        public OrderController(IAllOrder _appDBContent, IssueBook _issueBook)
        {
            allOrders = _appDBContent;
            issueBook = _issueBook;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
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
            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
