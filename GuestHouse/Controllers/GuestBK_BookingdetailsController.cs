//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using GuestHouse;
//using GuestHouse.Data;

//namespace GuestHouse.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GuestBK_BookingdetailsController : ControllerBase
//    {
//        private readonly DataContext _context;

//        public GuestBK_BookingdetailsController(DataContext context)
//        {
//            _context = context;
//        }

//        // GET: api/GuestBK_Bookingdetails
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<GuestBK_Bookingdetails>>> GetguestBK_Bookingdetails()
//        {
//          if (_context.guestBK_Bookingdetails == null)
//          {
//              return NotFound();
//          }
//            return await _context.guestBK_Bookingdetails.ToListAsync();
//        }

//        // GET: api/GuestBK_Bookingdetails/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<GuestBK_Bookingdetails>> GetGuestBK_Bookingdetails(string id)
//        {
//          if (_context.guestBK_Bookingdetails == null)
//          {
//              return NotFound();
//          }
//            var guestBK_Bookingdetails = await _context.guestBK_Bookingdetails.FindAsync(id);

//            if (guestBK_Bookingdetails == null)
//            {
//                return NotFound();
//            }

//            return guestBK_Bookingdetails;
//        }

//        // PUT: api/GuestBK_Bookingdetails/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutGuestBK_Bookingdetails(string id, GuestBK_Bookingdetails guestBK_Bookingdetails)
//        {
//            if (id != guestBK_Bookingdetails.ReqForTkt)
//            {
//                return BadRequest();
//            }

//            _context.Entry(guestBK_Bookingdetails).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!GuestBK_BookingdetailsExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/GuestBK_Bookingdetails
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<GuestBK_Bookingdetails>> PostGuestBK_Bookingdetails(GuestBK_Bookingdetails guestBK_Bookingdetails)
//        {
//          if (_context.guestBK_Bookingdetails == null)
//          {
//              return Problem("Entity set 'DataContext.guestBK_Bookingdetails'  is null.");
//          }
//            _context.guestBK_Bookingdetails.Add(guestBK_Bookingdetails);
//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateException)
//            {
//                if (GuestBK_BookingdetailsExists(guestBK_Bookingdetails.ReqForTkt))
//                {
//                    return Conflict();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return CreatedAtAction("GetGuestBK_Bookingdetails", new { id = guestBK_Bookingdetails.ReqForTkt }, guestBK_Bookingdetails);
//        }

//        // DELETE: api/GuestBK_Bookingdetails/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteGuestBK_Bookingdetails(string id)
//        {
//            if (_context.guestBK_Bookingdetails == null)
//            {
//                return NotFound();
//            }
//            var guestBK_Bookingdetails = await _context.guestBK_Bookingdetails.FindAsync(id);
//            if (guestBK_Bookingdetails == null)
//            {
//                return NotFound();
//            }

//            _context.guestBK_Bookingdetails.Remove(guestBK_Bookingdetails);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool GuestBK_BookingdetailsExists(string id)
//        {
//            return (_context.guestBK_Bookingdetails?.Any(e => e.ReqForTkt == id)).GetValueOrDefault();
//        }
//    }
//}

#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuestHouse;
using Microsoft.AspNetCore.Cors;
using GuestHouse.Data;
using Microsoft.Data.SqlClient;

namespace GuestHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestBK_BookingdetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public GuestBK_BookingdetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GuestBK_Bookingdetails
        [EnableCors("myAllowSpecificOrigins")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestBK_Bookingdetails>>> GetguestBK_Bookingdetails()
        {
            return await _context.guestBK_Bookingdetails.FromSqlRaw("Exec FetchReqNom").ToListAsync();
        }

       
        // GET: api/GuestBK_Bookingdetails/5
        //[EnableCors("myAllowSpecificOrigins")]
        //[HttpGet("{id}")]
        //public async Task<ActionResult<GuestBK_Bookingdetails>> GetGuestBK_Bookingdetails(string id)
        //{
        //    var guestBK_Bookingdetails = await _context.guestBK_Bookingdetails.FindAsync(id);

        //    if (guestBK_Bookingdetails == null)
        //    {
        //        return NotFound();
        //    }

        //    return guestBK_Bookingdetails;
        //}

        // PUT: api/GuestBK_Bookingdetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[EnableCors("myAllowSpecificOrigins")]
        [HttpPut("{id}")]
        public async Task<IActionResult>PutGuestBK_Bookingdetails(string id, GuestBK_Bookingdetails guestBK_Bookingdetails)
        {
            if (id != guestBK_Bookingdetails.ReqForTkt)
            {
                return BadRequest();
            }

            _context.Entry(guestBK_Bookingdetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestBK_BookingdetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();


           // var result = await _context.guestBK_Bookingdetails.FromSqlRaw("Exec update GuestBk_Bookingdetails where reqnom=@id").ToListAsync();

        }

        // POST: api/GuestBK_Bookingdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [EnableCors("myAllowSpecificOrigins")]
        [HttpPost]
        public async Task<ActionResult<GuestBK_Bookingdetails>> PostGuestBK_Bookingdetails(GuestBK_Bookingdetails guestBK_Bookingdetails)
        {
            var parameters = new[]
            {

                new SqlParameter("@0",guestBK_Bookingdetails.Location),
                new SqlParameter("@1",guestBK_Bookingdetails.Guest),
                new SqlParameter("@2",guestBK_Bookingdetails.NoOfGuest),
                new SqlParameter("@3",guestBK_Bookingdetails.ReqForTkt),
                new SqlParameter("@4",guestBK_Bookingdetails.ReqForName),
                new SqlParameter("@5",guestBK_Bookingdetails.ReqForEmail),
                new SqlParameter("@6",guestBK_Bookingdetails.ReqForGender),
                new SqlParameter("@7",guestBK_Bookingdetails.ReqForContactNo),
                new SqlParameter("@8",guestBK_Bookingdetails. BookingFromDate),
                new SqlParameter("@9",guestBK_Bookingdetails.BookingToDate),
                new SqlParameter("@10",guestBK_Bookingdetails.ArrivalTime),
                new SqlParameter("@11",guestBK_Bookingdetails.DepartureTime),
                new SqlParameter("@12",guestBK_Bookingdetails.ChargesApplied),
                new SqlParameter("@13",guestBK_Bookingdetails.ReqRemark),
                new SqlParameter("@14",guestBK_Bookingdetails.Breakfast),
                new SqlParameter("@15",guestBK_Bookingdetails.Lunch),
                new SqlParameter("@16",guestBK_Bookingdetails.Dinner),
                new SqlParameter("@17",guestBK_Bookingdetails.ReqByTkt),
                new SqlParameter("@18",guestBK_Bookingdetails.ReqByName),
                new SqlParameter("@19",guestBK_Bookingdetails.ReqByEmail),
                new SqlParameter("@20",guestBK_Bookingdetails.SBG),
                new SqlParameter("@21",guestBK_Bookingdetails.MSTGRDCD),
                new SqlParameter("@22",guestBK_Bookingdetails.DEPTNM),
                new SqlParameter("@23",guestBK_Bookingdetails.age),

            };

            var Aarti = await _context.guestBK_Bookingdetails.FromSqlRaw("exec BKDetails @0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23", parameters).ToListAsync();
            _context.guestBK_Bookingdetails.Add(guestBK_Bookingdetails);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetGuestBK_Bookingdetails", new { id = guestBK_Bookingdetails.ReqForTkt }, guestBK_Bookingdetails);
        }


        // DELETE: api/GuestBK_Bookingdetails/5
        [EnableCors("myAllowSpecificOrigins")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuestBK_Bookingdetails(string id)
        {
            var guestBK_Bookingdetails = await _context.guestBK_Bookingdetails.FindAsync(id);
            if (guestBK_Bookingdetails == null)
            {
                return NotFound();
            }

            _context.guestBK_Bookingdetails.Remove(guestBK_Bookingdetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GuestBK_BookingdetailsExists(string id)
        {
            return _context.guestBK_Bookingdetails.Any(e => e.ReqForTkt == id);
        }
    }
}

