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
    public class FoodDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public FoodDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/FoodDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodDetails>>> GetFoodDetails()
        {
          if (_context.FoodDetails == null)
          {
              return NotFound();
          }
            return await _context.FoodDetails.ToListAsync();
        }

        // GET: api/FoodDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodDetails>> GetFoodDetails(string id)
        {
          if (_context.FoodDetails == null)
          {
              return NotFound();
          }
            var foodDetails = await _context.FoodDetails.FindAsync(id);

            if (foodDetails == null)
            {
                return NotFound();
            }

            return foodDetails;
        }

        // PUT: api/FoodDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoodDetails(string id, FoodDetails foodDetails)
        {
            if (id != foodDetails.LOCATION)
            {
                return BadRequest();
            }

            _context.Entry(foodDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodDetailsExists(id))
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

        // POST: api/FoodDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodDetails>> PostFoodDetails(FoodDetails foodDetails)
        {

            var parameters = new[]
            {

                new SqlParameter("@0",foodDetails.LOCATION),
                new SqlParameter("@1",foodDetails.ReqByTkt),
                new SqlParameter("@2",foodDetails.ReqForTkt),
                new SqlParameter("@3",foodDetails.bookingdate),
                new SqlParameter("@4",foodDetails.Reqnom),
                new SqlParameter("@5",foodDetails.Floor),
                new SqlParameter("@6",foodDetails.Breakfast),
                new SqlParameter("@7",foodDetails.Lunch),
                new SqlParameter("@8",foodDetails. Dinner),
                new SqlParameter("@9",foodDetails.Status_food)
            };



            var Aarti = await _context.FoodDetails.FromSqlRaw("exec FoodDetails @0,@1,@2,@3,@4,@5,@6,@7,@8,@9", parameters).ToListAsync();
            _context.FoodDetails.Add(foodDetails);
            await _context.SaveChangesAsync();

           return CreatedAtAction("GetFoodDetails", new { id = foodDetails.LOCATION }, foodDetails);
        }

        // DELETE: api/FoodDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodDetails(string id)
        {
            if (_context.FoodDetails == null)
            {
                return NotFound();
            }
            var foodDetails = await _context.FoodDetails.FindAsync(id);
            if (foodDetails == null)
            {
                return NotFound();
            }

            _context.FoodDetails.Remove(foodDetails);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodDetailsExists(string id)
        {
            return (_context.FoodDetails?.Any(e => e.LOCATION == id)).GetValueOrDefault();
        }
    }
}
