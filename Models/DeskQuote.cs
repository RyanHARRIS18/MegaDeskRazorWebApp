using MegaDeskWeb2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskRazorPages.Models
{
    public class DeskQuote
    {
        [Display(Name = "Desktop Quote")]
        public int DeskQuoteId { get; set; }

        public Desk Desk { get; set; }

        public int DeskId { get; set; }
        public DateTime Date { get; set; }

        [Display(Name = "Customer Name")]
        public String CustomerName { get; set; }


        [Display(Name = "Quote Price")]
        public decimal QuotePrice { get; set; }


        [Display(Name = "Rush Order")]
        public Delivery Delivery { get; set; }

        public int DeliveryId { get; set; }

        public decimal GetQuotePrice(MegaDeskWeb2Context context)
        {
            decimal quotePrice = 200.00M;
            


            decimal surfaceArea = this.Desk.Depth * this.Desk.Width;
            Console.WriteLine(surfaceArea);
            decimal surfacePrice = 0.00M;

            if (surfaceArea > 1000)
            {
                surfacePrice += (surfaceArea - 1000);
            }

            quotePrice += 50 * this.Desk.Drawers;
            Console.WriteLine(quotePrice);

            decimal surfaceMaterialPrice = 0.00M;


            var surfaceMaterialPrices = context.DesktopMaterial
                 .Where(d => d.DesktopMaterialId == this.Desk.DesktopMaterialId).FirstOrDefault();

            surfaceMaterialPrice = surfaceMaterialPrices.Price;

            decimal shippingPrice = 0.00M;

            var ShippingPrices = context.Delivery
                .Where(d => d.DeliveryId == this.DeliveryId).FirstOrDefault();

            if (surfaceArea < 1000)
            {
                shippingPrice = ShippingPrices.PriceUnder1000;
            }
            else if(surfaceArea <= 2000)
            {
                shippingPrice = ShippingPrices.PriceUnder1000;
            }
            else
            {
                shippingPrice = ShippingPrices.PriceGreaterThan2000;
            }
            Console.WriteLine(shippingPrice);
            quotePrice += shippingPrice + surfacePrice + surfaceMaterialPrice;
            Console.WriteLine(quotePrice);       

            return quotePrice;
        }
    }

}