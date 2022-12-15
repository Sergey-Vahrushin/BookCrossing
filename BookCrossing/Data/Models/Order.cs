using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }

        public int UseId { get; set; }

        public int DepartmentId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
