using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WLibrary.DAL.Data;
using WLibrary.DAL.Entities;

namespace Lab_Zhuliuk_90331.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlantsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Plantses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plants>>> GetPlantses(int? group)
        {
            return await _context
                .Plantses
                .Where(d => !group.HasValue
                || d.PlantsGroupId.Equals(group.Value)) 
                ?.ToListAsync();
        }

        // GET: api/Plantses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plants>> GetPlants(int id)
        {
            var plants = await _context.Plantses.FindAsync(id);

            if (plants == null)
            {
                return NotFound();
            }

            return plants;
        }

        // PUT: api/Plantses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlants(int id, Plants plants)
        {
            if (id != plants.PlantsId)
            {
                return BadRequest();
            }

            _context.Entry(plants).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Plantses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plants>> PostPlants(Plants plants)
        {
            _context.Plantses.Add(plants);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlants", new { id = plants.PlantsId }, plants);
        }

        // DELETE: api/Plantses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlants(int id)
        {
            var plants = await _context.Plantses.FindAsync(id);
            if (plants == null)
            {
                return NotFound();
            }

            _context.Plantses.Remove(plants);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantsExists(int id)
        {
            return _context.Plantses.Any(e => e.PlantsId == id);
        }
    }
}
