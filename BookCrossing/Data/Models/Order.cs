using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCrossing.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime CreateTime { get; set; }

        [Display(Name="Имя")]
        [StringLength(20)]
        public string Name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(20)]
        public string SurName { get; set; }

        [Display(Name = "Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage = "Длина номера не менее 10 знаков")]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Неверный Email адрес")]
        public string Email { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
