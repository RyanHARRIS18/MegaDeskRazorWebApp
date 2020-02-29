using MegaDeskWeb2.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace MegaDeskWeb2.Models
{
    public class SeedData
    { 
            public static void Initialize(IServiceProvider serviceProvider)
            {
                using (var context = new MegaDeskWeb2Context(
                    serviceProvider.GetRequiredService<
                        DbContextOptions<MegaDeskWeb2Context>>()))
                {
                    // Look for any movies.
                    if (context.DesktopMaterial.Any())
                    {
                        return;   // DB has been seeded
                    }

                    context.DesktopMaterial.AddRange(
                        new MegaDeskRazorPages.Models.DesktopMaterial
                        {
                            DesktopMaterialName = "Oak",
                            Price = 200
                        },
                        new MegaDeskRazorPages.Models.DesktopMaterial
                         {
                            DesktopMaterialName = "Laminate",
                            Price = 100
                        },
                         new MegaDeskRazorPages.Models.DesktopMaterial
                         {
                            DesktopMaterialName = "Pine",
                            Price = 50
                        },
                          new MegaDeskRazorPages.Models.DesktopMaterial
                          {
                            DesktopMaterialName = "Veneer",
                            Price = 125
                        },
                         new MegaDeskRazorPages.Models.DesktopMaterial
                         {
                            DesktopMaterialName = "Rosewood",
                            Price = 300
                        }
                    );

                    context.Delivery.AddRange(
                          new MegaDeskRazorPages.Models.Delivery
                          {
                            DeliveryName = "3 Day",
                            PriceBetween1000And2000 = 60,
                            PriceGreaterThan2000 =  70,
                            PriceUnder1000 = 80
                            
                        },
                         new MegaDeskRazorPages.Models.Delivery
                         {
                             DeliveryName = "5 Day",
                             PriceBetween1000And2000 = 40,
                             PriceGreaterThan2000 = 50,
                             PriceUnder1000 = 60
                         },
                         new MegaDeskRazorPages.Models.Delivery
                         {
                             DeliveryName = "7 Day",
                             PriceBetween1000And2000 = 30,
                             PriceGreaterThan2000 = 35,
                             PriceUnder1000 = 40
                         },
                         new MegaDeskRazorPages.Models.Delivery
                         {
                             DeliveryName = "14 Day",
                                 PriceBetween1000And2000 = 0,
                             PriceGreaterThan2000 = 0,
                             PriceUnder1000 = 0
                         }
                        );

                    context.SaveChanges();
                }
            }
        }
    }

