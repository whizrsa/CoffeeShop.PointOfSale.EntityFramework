﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.PointOfSale.EntityFramework.Models
{
    internal class Order
    {
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
