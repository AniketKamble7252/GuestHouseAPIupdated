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
    public class RoomAllocationsController : ControllerBase
    {
        private readonly DataContext _context;

        public RoomAllocationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/RoomAllocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomAllocation>>> GetRoomAllocation()
        {
          if (_context.RoomAllocation == null)
          {
              return NotFound();
          }
            return await _context.RoomAllocation.ToListAsync();
        }

        // GET: api/RoomAllocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomAllocation>> GetRoomAllocation(int id)
        {
          if (_context.RoomAllocation == null)
          {
              return NotFound();
          }
            var roomAllocation = await _context.RoomAllocation.FindAsync(id);

            if (roomAllocation == null)
            {
                return NotFound();
            }

            return roomAllocation;
        }

        // PUT: api/RoomAllocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IEnumerable<IActionResult>> PutRoomAllocation(int id, RoomAllocation roomAllocation)
        {


            var parameters = new[]
            {

                //new SqlParameter("@0",roomAllocation.reqnom),
                new SqlParameter("@1",roomAllocation.RoomNo),
                new SqlParameter("@2",roomAllocation.reqnom),

            };

            var result = await _context.RoomAllocation.FromSqlRaw("Exec insert_RoomNo @1,@2", parameters).ToListAsync();
            return (IEnumerable<IActionResult>)result;
            //if (id != roomAllocation.reqnom)
            // {
            //   return BadRequest();
            //}

            //_context.Entry(roomAllocation).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!RoomAllocationExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return NoContent();
        }

        // POST: api/RoomAllocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomAllocation>> PostRoomAllocation(RoomAllocation roomAllocation)
        {
          if (_context.RoomAllocation == null)
          {
              return Problem("Entity set 'DataContext.RoomAllocation'  is null.");
          }
            _context.RoomAllocation.Add(roomAllocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomAllocation", new { id = roomAllocation.reqnom }, roomAllocation);
        }

        // DELETE: api/RoomAllocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomAllocation(int id)
        {
            if (_context.RoomAllocation == null)
            {
                return NotFound();
            }
            var roomAllocation = await _context.RoomAllocation.FindAsync(id);
            if (roomAllocation == null)
            {
                return NotFound();
            }

            _context.RoomAllocation.Remove(roomAllocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomAllocationExists(int id)
        {
            return (_context.RoomAllocation?.Any(e => e.reqnom == id)).GetValueOrDefault();
        }
    }
}
