using BookCrossing.Data.Interfaces;
using BookCrossing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Repository
{
    public class OrderRepository : IAllOrder
    {
        private readonly AppDBContent appDBContent;

        private readonly IssueBook issueBook;

        public OrderRepository(AppDBContent _appDBContent, IssueBook _issueBook)
        {
            appDBContent = _appDBContent;
            issueBook = _issueBook;
        }

        public void CreateOrder(Order order)
        {
            order.CreateTime = DateTime.Now;
            appDBContent.Order.Add(order);

            var items = issueBook.ListIssueBookItems;

            foreach (var element in items)
            {
                var orderDetail = new OrderDetail()
                {
                    BookId = element.Book.Id,
                    OrderId = order.Id
                };

                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChangesAsync();
        }
    }
}
