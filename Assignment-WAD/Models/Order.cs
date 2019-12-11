﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_WAD.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int PaymentTypeId { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipPhone { get; set; }

        public double TotalPrice { get; set; }
        public long CreatedAt { get; set; }
        public long UpdatedAt { get; set; }
        public long DeletedAt { get; set; }
        public int Status { get; set; }

        public enum OrderStatus { Pending = 5, Confirmed = 4, Shipping = 3, Paid = 2, Done = 1, Cancel = 0, Deleted = -1 }
        public enum PaymentType { Cod = 1, InternetBanking = 2, DirectTransfer = 3 }


        public Order()
        {
            CreatedAt = DateTime.Now.Millisecond;
            UpdatedAt = DateTime.Now.Millisecond;
            Status = (int)OrderStatus.Pending;
        }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
