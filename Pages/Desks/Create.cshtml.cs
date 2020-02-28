using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskRazorPages.Models;
using MegaDeskWeb2.Data;
namespace MegaDeskWeb2
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWeb2.Data.MegaDeskWeb2Context _context;

        public CreateModel(MegaDeskWeb2.Data.MegaDeskWeb2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Console.WriteLine("GOT HERE");
            ViewData["DeliveryId"] = new SelectList(_context.Set<Delivery>(), "DeliveryId", "DeliveryName");
            ViewData["DesktopMaterialId"] = new SelectList(_context.Set<DesktopMaterial>(),"DesktopMaterialId", "DesktopMaterialName");
            
            return Page();
        }



        [BindProperty]
        public Desk Desk { get; set; }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("GOT HERE");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Desk.Add(Desk);
            await _context.SaveChangesAsync();

            DeskQuote.DeskId = Desk.DeskId;

            DeskQuote.Desk = Desk;

            DeskQuote.Date = DateTime.Now;

            Console.WriteLine("GOT HERE");
            
            DeskQuote.QuotePrice = DeskQuote.GetQuotePrice(_context);

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}