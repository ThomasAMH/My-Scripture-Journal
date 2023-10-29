using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using My_Scripture_Journal.Data;
using My_Scripture_Journal.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;

namespace My_Scripture_Journal.Pages.Entries
{
    public class IndexModel : PageModel
    {
        private readonly My_Scripture_Journal.Data.My_Scripture_JournalContext _context;

        public IndexModel(My_Scripture_Journal.Data.My_Scripture_JournalContext context)
        {
            _context = context;
        }

        public IList<Entry> Entry { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Books { get; set; }
        [BindProperty(SupportsGet = true)]
        public string EntryBook { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime EntryCreateDate { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from m in _context.Entry
                                            orderby m.Book
                                            select m.Book;

            var entries = from r in _context.Entry
                         select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                entries = entries.Where(s => s.ImpressionNote.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(EntryBook))
            {
                entries = entries.Where(x => x.Book == EntryBook);
            }
            if (!(EntryCreateDate == DateTime.MinValue))
            {
                entries = entries.Where(x => x.EntryDate == EntryCreateDate);
            }
            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Entry = await entries.ToListAsync();
        }
    }
}
