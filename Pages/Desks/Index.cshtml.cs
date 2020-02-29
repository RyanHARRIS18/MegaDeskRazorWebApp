using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb2.Data;
using MegaDeskRazorPages.Models;

namespace MegaDeskWeb2
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb2Context _context;

        public IndexModel(MegaDeskWeb2Context context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get; set; }

        [BindProperty(SupportsGet =true)]
        public string searchString { get; set; }
        
        
        [BindProperty(SupportsGet = true)]
        public string NameSort { get; set; }

        [BindProperty(SupportsGet = true)]
        public string DateSort { get; set; }



      

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            var deskQuote = from m in _context.DeskQuote
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                deskQuote = deskQuote.Where(s => s.CustomerName.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "name_desc":
                        deskQuote = deskQuote.OrderByDescending(m => m.CustomerName);
                        break;
                    case "Date":
                        deskQuote = deskQuote.OrderBy(m => m.Date);
                        break;
                    case "date_desc":
                        deskQuote = deskQuote.OrderByDescending(m => m.Date);
                        break;
                    default:
                        deskQuote = deskQuote.OrderBy(m => m.CustomerName);
                        break;
                }
            }

            DeskQuote = await deskQuote.AsNoTracking().ToListAsync();
      /*      DeskQuote = await _context.DeskQuote.ToListAsync();*/
        }
    }
}
