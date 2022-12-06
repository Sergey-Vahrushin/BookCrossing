using BookCrossing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Interfaces
{
    interface IUser
    {
        User GetObjectUser(int userID);
    }
}
