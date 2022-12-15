using BookCrossing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Interfaces
{
    public interface IAllOrder
    {
        void CreateOrder(Order order);
    }
}
