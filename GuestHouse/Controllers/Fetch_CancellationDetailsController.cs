#nullable disable
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
using Microsoft.AspNetCore.Cors;
namespace GuestHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Fetch_CancellationDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public Fetch_CancellationDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Fetch_CancellationDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fetch_CancellationDetails>>> GetFetch_CancellationDetails()
        {
            return await _context.Fetch_CancellationDetails.FromSqlRaw("Exec FetchReqNom").ToListAsync();
        }

        // GET: api/Fetch_CancellationDetails/5
        [EnableCors("myAllowSpecificOrigins")]
        [HttpGet("{ReqByTkt}")]
        public async Task<ActionResult<IEnumerable<Fetch_CancellationDetails>>> GetFetch_CancellationDetails(string ReqByTkt)
        {
            
            var parameters = new[]
            {
                new SqlParameter("@0", ReqByTkt)
            };

            var result = await _context.Fetch_CancellationDetails.FromSqlRaw("Exec Fetch_CancellationDetails @0", parameters).ToListAsync();
            return result;
        }

        // PUT: api/Fetch_CancellationDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IEnumerable<IActionResult>> PutFetch_CancellationDetails(string id, Fetch_CancellationDetails fetch_CancellationDetails)
        {


            var parameters = new[]
            {

                //new SqlParameter("@0",roomAllocation.reqnom),
                new SqlParameter("@1",id),
                

            };

            var result = await _context.Fetch_CancellationDetails.FromSqlRaw("Exec Cancellation @1", parameters).ToListAsync();
            return (IEnumerable<IActionResult>)result;



            //    if (id != fetch_CancellationDetails.ReqByTkt)
            //    {
            //        return BadRequest();
            //    }

            //    _context.Entry(fetch_CancellationDetails).State = EntityState.Modified;

            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!Fetch_CancellationDetailsExists(id))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            //    return NoContent();
        }

        // POST: api/Fetch_CancellationDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Fetch_CancellationDetails>> PostFetch_CancellationDetails(Fetch_CancellationDetails fetch_CancellationDetails)
        //{
        //    _context.Fetch_CancellationDetails.Add(fetch_CancellationDetails);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (Fetch_CancellationDetailsExists(fetch_CancellationDetails.ReqByTkt))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetFetch_CancellationDetails", new { id = fetch_CancellationDetails.ReqByTkt }, fetch_CancellationDetails);
        //}

        // DELETE: api/Fetch_CancellationDetails/5
        [HttpDelete("{Reqnom}")]
        public async Task<IActionResult> DeleteFetch_CancellationDetails(int Reqnom)
        {
            var parameters = new[]
            {
                 new SqlParameter("@0",Reqnom)
            };
            var fetch_CancellationDetails = await _context.Fetch_CancellationDetails.FromSqlRaw("exec Cancellation @0",parameters).ToListAsync();
            

            //_context.Fetch_CancellationDetails.Remove(fetch_CancellationDetails);
            await _context.SaveChangesAsync();

            return NoContent();


        }

        //private bool Fetch_CancellationDetailsExists(string id)
        //{
        //    return _context.Fetch_CancellationDetails.Any(e => e.ReqByTkt == id);
        //}
    }
}
