using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WLibrary.DAL.Data;
using WLibrary.DAL.Entities;

namespace Lab_Zhuliuk_90331.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WLibrary.DAL.Data.ApplicationDbContext _context;

        public IndexModel(WLibrary.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Plants> Plants { get;set; }

        public async Task OnGetAsync()
        {
            Plants = await _context.Plantses
                .Include(p => p.Group).ToListAsync();
        }
    }
}
