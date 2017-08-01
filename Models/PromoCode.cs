using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deerfly_Patches.Models
{
    public class PromoCode
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Product PromotionalItem { get; set; }
        public decimal PromotionalItemPrice { get; set; }
        public Product WithPurchaseOf { get; set; }
        public decimal MinimumQualifyingPurchase { get; set; }
        public decimal PercentOffItem { get; set; }
        public decimal PercentOffOrder { get; set; }
        public decimal SpecialPrice { get; set; }
        public Product SpecialPriceItem { get; set; }
        public DateTime CodeStart { get; set; }
        public DateTime CodeEnd { get; set; }
    }
}
