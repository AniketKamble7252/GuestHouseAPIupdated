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
    public class CheckInOutRoomTransController : ControllerBase
    {
        private readonly DataContext _context;

        public CheckInOutRoomTransController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CheckInOutRoomTrans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckInOutRoomTrans>>> GetCheckInOutRoomTrans()
        {
          if (_context.CheckInOutRoomTrans == null)
          {
              return NotFound();
          }
            return await _context.CheckInOutRoomTrans.ToListAsync();
        }

        // GET: api/CheckInOutRoomTrans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CheckInOutRoomTrans>> GetCheckInOutRoomTrans(int id)
        {
          if (_context.CheckInOutRoomTrans == null)
          {
              return NotFound();
          }
            var checkInOutRoomTrans = await _context.CheckInOutRoomTrans.FindAsync(id);

            if (checkInOutRoomTrans == null)
            {
                return NotFound();
            }

            return checkInOutRoomTrans;
        }

        // PUT: api/CheckInOutRoomTrans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IEnumerable<IActionResult>> PutCheckInOutRoomTrans(int id, CheckInOutRoomTrans checkInOutRoomTrans)
        {
            var parameters = new[]
           {

                //new SqlParameter("@0",roomAllocation.reqnom),
                new SqlParameter("@1",checkInOutRoomTrans.Reqnom),
                new SqlParameter("@2",checkInOutRoomTrans.CheckinTime),
                new SqlParameter("@3",checkInOutRoomTrans.CheckoutTime),
                new SqlParameter("@4",checkInOutRoomTrans.RoomNo),

            };

            var result = await _context.CheckInOutRoomTrans.FromSqlRaw("Exec CheckInOutRoomTrans @1,@2,@3,@4", parameters).ToListAsync();
            return (IEnumerable<IActionResult>)result;
        }
        // POST: api/CheckInOutRoomTrans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CheckInOutRoomTrans>> PostCheckInOutRoomTrans(CheckInOutRoomTrans checkInOutRoomTrans)
        {
          if (_context.CheckInOutRoomTrans == null)
          {
              return Problem("Entity set 'DataContext.CheckInOutRoomTrans'  is null.");
          }
            _context.CheckInOutRoomTrans.Add(checkInOutRoomTrans);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheckInOutRoomTrans", new { id = checkInOutRoomTrans.Reqnom }, checkInOutRoomTrans);
        }

        // DELETE: api/CheckInOutRoomTrans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheckInOutRoomTrans(int id)
        {
            if (_context.CheckInOutRoomTrans == null)
            {
                return NotFound();
            }
            var checkInOutRoomTrans = await _context.CheckInOutRoomTrans.FindAsync(id);
            if (checkInOutRoomTrans == null)
            {
                return NotFound();
            }

            _context.CheckInOutRoomTrans.Remove(checkInOutRoomTrans);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheckInOutRoomTransExists(int id)
        {
            return (_context.CheckInOutRoomTrans?.Any(e => e.Reqnom == id)).GetValueOrDefault();
        }
    }
}
