using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WLibrary.DAL.Data;
using WLibrary.DAL.Entities;
using System.IO;

namespace Lab_Zhuliuk_90331.Areas.Admin.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _environment = env;

        }

        public IActionResult OnGet()
        {
        ViewData["PlantsGroupId"] = new SelectList(_context.PlantsGroups, "PlantsGroupId", "GroupName");
            return Page();
        }

        [BindProperty]
        public Plants Plants { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Plantses.Add(Plants);
            await _context.SaveChangesAsync();
            if (Image != null)
            {
                var fileName = $"{Plants.PlantsId}" + Path.GetExtension(Image.FileName);
                Plants.Image = fileName;
                var path = Path.Combine(_environment.WebRootPath, "Images",
                fileName);
                using (var fStream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(fStream);
                }
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
