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
    public class DetailsModel : PageModel
    {
        private readonly WLibrary.DAL.Data.ApplicationDbContext _context;

        public DetailsModel(WLibrary.DAL.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Plants Plants { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plants = await _context.Plantses
                .Include(p => p.Group).FirstOrDefaultAsync(m => m.PlantsId == id);

            if (Plants == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
