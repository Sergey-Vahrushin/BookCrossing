using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookCrossing.Data.Interfaces;
using BookCrossing.Data.Models;
using BookCrossing.Data.Repository;
using BookCrossing.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookCrossing.Controllers
{
    public class IssueBookController : Controller
    {
        private readonly IBook bookRep;
        private readonly IssueBook _issueBook;

        public IssueBookController(IBook book, IssueBook issueBook)
        {
            bookRep = book;
            _issueBook = issueBook;
        }


        public ViewResult Index()
        {
            var items = _issueBook.GetIssueItems();
            _issueBook.ListIssueBookItems = items;

            var obj = new IssueBookViewModel
            {
                IssueBook = _issueBook
            };

            return View(obj);
        }


        public RedirectToActionResult AddToIssue(int bookID)
        {
            var item = bookRep.Books.FirstOrDefault(i => i.Id == bookID);
            if (item != null)
            {
                _issueBook.AddToIssue(item);
            }
            return RedirectToAction("Index");
        }

    }
}