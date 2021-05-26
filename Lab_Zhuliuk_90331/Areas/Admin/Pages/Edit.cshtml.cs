using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WLibrary.DAL.Data;
using WLibrary.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Lab_Zhuliuk_90331.Areas.Admin.Pages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _environment;


        public EditModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;

        }

        [BindProperty]
        public Plants Plants { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }


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
           ViewData["PlantsGroupId"] = new SelectList(_context.PlantsGroups, "PlantsGroupId", "GroupName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Image != null)
            {
                var fileName = $"{Plants.PlantsId}" +
                Path.GetExtension(Image.FileName);
                Plants.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images",
                fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
            }





            _context.Attach(Plants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantsExists(Plants.PlantsId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlantsExists(int id)
        {
            return _context.Plantses.Any(e => e.PlantsId == id);
        }
    }
}
