using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using My_Scripture_Journal.Data;
using My_Scripture_Journal.Models;

namespace My_Scripture_Journal.Pages.Entries
{
    public class DetailsModel : PageModel
    {
        private readonly My_Scripture_Journal.Data.My_Scripture_JournalContext _context;

        public DetailsModel(My_Scripture_Journal.Data.My_Scripture_JournalContext context)
        {
            _context = context;
        }

      public Entry Entry { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Entry == null)
            {
                return NotFound();
            }

            var entry = await _context.Entry.FirstOrDefaultAsync(m => m.ID == id);
            if (entry == null)
            {
                return NotFound();
            }
            else 
            {
                Entry = entry;
            }
            return Page();
        }
    }
}
