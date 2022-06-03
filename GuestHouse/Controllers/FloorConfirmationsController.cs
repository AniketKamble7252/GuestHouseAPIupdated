using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuestHouse;
using GuestHouse.Data;
using Microsoft.Data.SqlClient;

namespace GuestHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FloorConfirmationsController : ControllerBase
    {
        private readonly DataContext _context;

        public FloorConfirmationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FloorConfirmations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FloorConfirmation>>> GetFloorConfirmation()
        {
          if (_context.FloorConfirmation == null)
          {
              return NotFound();
          }
            return await _context.FloorConfirmation.ToListAsync();
        }

        // GET: api/FloorConfirmations/5
        [HttpGet("{location}")]
        public async Task<ActionResult<IEnumerable<FloorConfirmation>>> GetFloorConfirmation(string location)
        {
            var parameters = new[]
              {
                new SqlParameter("@0", location)
            };

            var result = await _context.FloorConfirmation.FromSqlRaw("Exec RoomAllocation @0", parameters).ToListAsync();
            return result;
        }

        // PUT: api/FloorConfirmations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFloorConfirmation(string id, FloorConfirmation floorConfirmation)
        {
            if (id != floorConfirmation.ROOMS)
            {
                return BadRequest();
            }

            _context.Entry(floorConfirmation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FloorConfirmationExists(id))
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

        // POST: api/FloorConfirmations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FloorConfirmation>> PostFloorConfirmation(FloorConfirmation floorConfirmation)
        {
          if (_context.FloorConfirmation == null)
          {
              return Problem("Entity set 'DataContext.FloorConfirmation'  is null.");
          }
            _context.FloorConfirmation.Add(floorConfirmation);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FloorConfirmationExists(floorConfirmation.ROOMS))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFloorConfirmation", new { id = floorConfirmation.ROOMS }, floorConfirmation);
        }

        // DELETE: api/FloorConfirmations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFloorConfirmation(string id)
        {
            if (_context.FloorConfirmation == null)
            {
                return NotFound();
            }
            var floorConfirmation = await _context.FloorConfirmation.FindAsync(id);
            if (floorConfirmation == null)
            {
                return NotFound();
            }

            _context.FloorConfirmation.Remove(floorConfirmation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FloorConfirmationExists(string id)
        {
            return (_context.FloorConfirmation?.Any(e => e.ROOMS == id)).GetValueOrDefault();
        }
    }
}
