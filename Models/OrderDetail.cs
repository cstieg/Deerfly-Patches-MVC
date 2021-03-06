﻿using System;

namespace Deerfly_Patches.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public Customer Purchaser { get; set; }
        public Product Item { get; set; }
        public DateTime PlacedInCart { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Shipping { get; set; }
        public bool CheckedOut { get; set; }
        public Order Order { get; set; }

        public decimal ExtendedPrice
        {
            get
            {
                return Quantity * UnitPrice;
            }

        }

        public decimal TotalPrice
        {
            get 
            {
                return ExtendedPrice + Shipping;
            }
        }
    }
}
