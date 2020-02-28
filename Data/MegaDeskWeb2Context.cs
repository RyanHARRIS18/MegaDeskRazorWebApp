using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazorPages.Models;

namespace MegaDeskWeb2.Data
{
    public class MegaDeskWeb2Context : DbContext
    {
        public MegaDeskWeb2Context (DbContextOptions<MegaDeskWeb2Context> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskRazorPages.Models.DeskQuote> DeskQuote { get; set; }
        public DbSet<MegaDeskRazorPages.Models.Desk> Desk { get; set; }

        public DbSet<MegaDeskRazorPages.Models.Delivery> Delivery { get; set; }

        public DbSet<MegaDeskRazorPages.Models.DesktopMaterial> DesktopMaterial { get; set; }


    }
}


/*
 [BIND property]
 public .include(d = d.deliveryType)
     
     
     
     
     
     */