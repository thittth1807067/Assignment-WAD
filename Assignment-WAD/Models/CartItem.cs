﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_WAD.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}