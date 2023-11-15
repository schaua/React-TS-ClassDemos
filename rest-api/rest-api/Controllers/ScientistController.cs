using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScientistAPI.Data;
using rest_api.Models;

namespace ScientistAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScientistController : ControllerBase
    {
        private readonly ScientistContext _context;

        public ScientistController(ScientistContext context)
        {
            _context = context;
        }

        // GET: api/Scientist
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scientist>>> GetScientists()
        {
            return await _context.Scientists.ToListAsync();
        }

        // GET: api/Scientist/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scientist>> GetScientist(int id)
        {
            var scientist = await _context.Scientists.FindAsync(id);

            if (scientist == null)
            {
                return NotFound();
            }

            return scientist;
        }

        // PUT: api/Scientist/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScientist(int id, Scientist scientist)
        {
            if (id != scientist.Id)
            {
                return BadRequest();
            }

            _context.Entry(scientist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScientistExists(id))
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

        // POST: api/Scientist
        [HttpPost]
        public async Task<ActionResult<Scientist>> PostScientist(Scientist scientist)
        {
            _context.Scientists.Add(scientist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScientist", new { id = scientist.Id }, scientist);
        }

        // DELETE: api/Scientist/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Scientist>> DeleteScientist(int id)
        {
            var scientist = await _context.Scientists.FindAsync(id);
            if (scientist == null)
            {
                return NotFound();
            }

            _context.Scientists.Remove(scientist);
            await _context.SaveChangesAsync();

            return scientist;
        }

        private bool ScientistExists(int id)
        {
            return _context.Scientists.Any(e => e.Id == id);
        }
    }
}
