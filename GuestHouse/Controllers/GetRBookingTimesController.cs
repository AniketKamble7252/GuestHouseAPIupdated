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
    public class GetRBookingTimesController : ControllerBase
    {
        private readonly DataContext _context;

        public GetRBookingTimesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GetRBookingTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetRBookingTime>>> GetGetRBookingTime()
        {
          if (_context.GetRBookingTime == null)
          {
              return NotFound();
          }
            return await _context.GetRBookingTime.ToListAsync();
        }

        // GET: api/GetRBookingTimes/5
        [HttpGet("{Location}/{Date}")]
        public async Task<ActionResult<IEnumerable<GetRBookingTime>>> GetGetRBookingTime(string Location, string Date)
        {

            var parameters = new[]
             {
                new SqlParameter("@0", Location),
                 new SqlParameter("@1",Date)
            };

            var result = await _context.GetRBookingTime.FromSqlRaw("Exec GetRBookingTime @0,@1", parameters).ToListAsync();
            return result;
            //if (_context.GetRBookingTime == null)
            //{
            //    return NotFound();
            //}
            //  var getRBookingTime = await _context.GetRBookingTime.FindAsync(id);

            //  if (getRBookingTime == null)
            //  {
            //      return NotFound();
            //  }

            //  return getRBookingTime;
        }

        // PUT: api/GetRBookingTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGetRBookingTime(string id, GetRBookingTime getRBookingTime)
        {
            if (id != getRBookingTime.RoomNo)
            {
                return BadRequest();
            }

            _context.Entry(getRBookingTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GetRBookingTimeExists(id))
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

        // POST: api/GetRBookingTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetRBookingTime>> PostGetRBookingTime(GetRBookingTime getRBookingTime)
        {
          if (_context.GetRBookingTime == null)
          {
              return Problem("Entity set 'DataContext.GetRBookingTime'  is null.");
          }
            _context.GetRBookingTime.Add(getRBookingTime);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (GetRBookingTimeExists(getRBookingTime.RoomNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetGetRBookingTime", new { id = getRBookingTime.RoomNo }, getRBookingTime);
        }

        // DELETE: api/GetRBookingTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGetRBookingTime(string id)
        {
            if (_context.GetRBookingTime == null)
            {
                return NotFound();
            }
            var getRBookingTime = await _context.GetRBookingTime.FindAsync(id);
            if (getRBookingTime == null)
            {
                return NotFound();
            }

            _context.GetRBookingTime.Remove(getRBookingTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GetRBookingTimeExists(string id)
        {
            return (_context.GetRBookingTime?.Any(e => e.RoomNo == id)).GetValueOrDefault();
        }
    }
}
