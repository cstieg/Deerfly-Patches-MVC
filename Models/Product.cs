﻿namespace Deerfly_Patches.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Shipping { get; set; }
        public string ImageURL { get; set; }
        public string Category { get; set; }
    }
}
