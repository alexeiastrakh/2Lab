using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceWebApplication.Models;

namespace SpaceWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExplorersController : ControllerBase
    {
        private readonly DBMissionContext _context;

        public ExplorersController(DBMissionContext context)
        {
            _context = context;
        }

        // GET: api/Explorers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Explorer>>> GetExplorers()
        {
          if (_context.Explorers == null)
          {
              return NotFound();
          }
            return await _context.Explorers.ToListAsync();
        }

        // GET: api/Explorers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Explorer>> GetExplorer(int id)
        {
          if (_context.Explorers == null)
          {
              return NotFound();
          }
            var explorer = await _context.Explorers.FindAsync(id);

            if (explorer == null)
            {
                return NotFound();
            }

            return explorer;
        }

        // PUT: api/Explorers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExplorer(int id, Explorer explorer)
        {
            if (id != explorer.ExplorerId)
            {
                return BadRequest();
            }

            _context.Entry(explorer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExplorerExists(id))
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

        // POST: api/Explorers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Explorer>> PostExplorer(Explorer explorer)
        {
          if (_context.Explorers == null)
          {
              return Problem("Entity set 'DBMissionContext.Explorers'  is null.");
          }
            _context.Explorers.Add(explorer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExplorer", new { id = explorer.ExplorerId }, explorer);
        }

        // DELETE: api/Explorers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExplorer(int id)
        {
            if (_context.Explorers == null)
            {
                return NotFound();
            }
            var explorer = await _context.Explorers.FindAsync(id);
            if (explorer == null)
            {
                return NotFound();
            }

            _context.Explorers.Remove(explorer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExplorerExists(int id)
        {
            return (_context.Explorers?.Any(e => e.ExplorerId == id)).GetValueOrDefault();
        }
    }
}
