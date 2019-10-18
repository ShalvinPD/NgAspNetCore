using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ngcore.Models;

namespace ngcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologiesController : ControllerBase
    {
        private readonly CMContext _context;

        public TechnologiesController(CMContext context)
        {
            _context = context;
        }

        // GET: api/Technologies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Technologies>>> GetTechnologies()
        {
            return await _context.Technologies.ToListAsync();
        }

        // GET: api/Technologies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Technologies>> GetTechnologies(int id)
        {
            var technologies = await _context.Technologies.FindAsync(id);

            if (technologies == null)
            {
                return NotFound();
            }

            return technologies;
        }

        // PUT: api/Technologies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnologies(int id, Technologies technologies)
        {
            if (id != technologies.TechId)
            {
                return BadRequest();
            }

            _context.Entry(technologies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnologiesExists(id))
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

        // POST: api/Technologies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Technologies>> PostTechnologies(Technologies technologies)
        {
            _context.Technologies.Add(technologies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTechnologies", new { id = technologies.TechId }, technologies);
        }

        // DELETE: api/Technologies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Technologies>> DeleteTechnologies(int id)
        {
            var technologies = await _context.Technologies.FindAsync(id);
            if (technologies == null)
            {
                return NotFound();
            }

            _context.Technologies.Remove(technologies);
            await _context.SaveChangesAsync();

            return technologies;
        }

        private bool TechnologiesExists(int id)
        {
            return _context.Technologies.Any(e => e.TechId == id);
        }
    }
}
