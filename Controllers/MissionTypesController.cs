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
    public class MissionTypesController : ControllerBase
    {
        private readonly DBMissionContext _context;

        public MissionTypesController(DBMissionContext context)
        {
            _context = context;
        }

        // GET: api/MissionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MissionType>>> GetMissionType()
        {
          if (_context.MissionType == null)
          {
              return NotFound();
          }
            return await _context.MissionType.ToListAsync();
        }

        // GET: api/MissionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MissionType>> GetMissionType(int id)
        {
          if (_context.MissionType == null)
          {
              return NotFound();
          }
            var missionType = await _context.MissionType.FindAsync(id);

            if (missionType == null)
            {
                return NotFound();
            }

            return missionType;
        }

        // PUT: api/MissionTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMissionType(int id, MissionType missionType)
        {
            if (id != missionType.MissionTypeId)
            {
                return BadRequest();
            }

            _context.Entry(missionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionTypeExists(id))
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

        // POST: api/MissionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MissionType>> PostMissionType(MissionType missionType)
        {
          if (_context.MissionType == null)
          {
              return Problem("Entity set 'DBMissionContext.MissionType'  is null.");
          }
            _context.MissionType.Add(missionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMissionType", new { id = missionType.MissionTypeId }, missionType);
        }

        // DELETE: api/MissionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMissionType(int id)
        {
            if (_context.MissionType == null)
            {
                return NotFound();
            }
            var missionType = await _context.MissionType.FindAsync(id);
            if (missionType == null)
            {
                return NotFound();
            }

            _context.MissionType.Remove(missionType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MissionTypeExists(int id)
        {
            return (_context.MissionType?.Any(e => e.MissionTypeId == id)).GetValueOrDefault();
        }
    }
}
