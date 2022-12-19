using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Models
{
    public class IssueBook
    {
        public string IssueBookId { get; set; }

        public List<IssueBookItem> ListIssueBookItems { get; set; }

        public DateTime IssueDate { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }


        private readonly AppDBContent AppDBContent;

        public IssueBook(AppDBContent _appDBContent)
        {
            AppDBContent = _appDBContent;
        }

        public static IssueBook GetIssue(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string issueBookId = session.GetString("IssueId") ?? Guid.NewGuid().ToString();

            session.SetString("IssueId", issueBookId);
            return new IssueBook(context) { IssueBookId = issueBookId };
        }

        public void AddToIssue(Book book)
        {
            AppDBContent.IssueBookItem.Add(new IssueBookItem
            {
                IssueBookId = IssueBookId,
                Book = book
            });

            AppDBContent.SaveChanges();
        }

        public void DeleteFromIssue(IssueBookItem bookItem)
        {
            AppDBContent.IssueBookItem.Remove(bookItem);

            AppDBContent.SaveChanges();
        }

        public List<IssueBookItem> GetIssueItems()
        {
            return AppDBContent.IssueBookItem.Where(c => c.IssueBookId == IssueBookId).Include(s => s.Book).ToList();
        }

    }
}
