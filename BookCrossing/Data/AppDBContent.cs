using BookCrossing.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookCrossing.Data
{
    public class AppDBContent : DbContext
    {
        
        public AppDBContent(DbContextOptions<AppDBContent> options): base(options)
        {
        }
        
        public DbSet<Book> Book { get; set; }

        public DbSet<Genre> Genre { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<IssueBookItem> IssueBookItem { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}
