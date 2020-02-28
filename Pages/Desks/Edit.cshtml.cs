using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazorPages.Models;
using MegaDeskWeb2.Data;

namespace MegaDeskWeb2
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskWeb2.Data.MegaDeskWeb2Context _context;

        public EditModel(MegaDeskWeb2.Data.MegaDeskWeb2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Console.WriteLine("GOT HERE");
            ViewData["DeliveryId"] = new SelectList(_context.Set<Delivery>(), "DeliveryId", "DeliveryName");
            ViewData["DesktopMaterialId"] = new SelectList(_context.Set<DesktopMaterial>(), "DesktopMaterialId", "DesktopMaterialName");


            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote.FindAsync(id);

            if (DeskQuote == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var studentToUpdate = await _context.DeskQuote.FindAsync(id);

            if (studentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<DeskQuote>(
                studentToUpdate,
                "deskquote",
                s => s.DeskId, s => s.Date, s => s.CustomerName, s => s.DeliveryId))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool DeskQuoteExists(int id)
        {
            return _context.DeskQuote.Any(e => e.DeskQuoteId == id);
        }
    }
}
