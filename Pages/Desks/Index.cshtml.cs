using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazorPages.Models;
using MegaDeskWeb2.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MegaDeskWeb2
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb2.Data.MegaDeskWeb2Context _context;
       
        [BindProperty(SupportsGet =true)]
        public string SearchString { get; set; }
/*
        [BindProperty(SupportsGet = true)]*/


        public IndexModel(MegaDeskWeb2.Data.MegaDeskWeb2Context context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync()
        {
            DeskQuote = await _context.DeskQuote.ToListAsync();
        }
    }
}
