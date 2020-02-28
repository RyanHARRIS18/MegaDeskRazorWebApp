using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskRazorPages.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        [Display(Name = "Delivery")]
        public string DeliveryName { get; set; }
        public decimal PriceUnder1000 { get; set; }
        public decimal PriceBetween1000And2000 { get; set; }

        public decimal PriceGreaterThan2000 { get; set; }

    }
}
