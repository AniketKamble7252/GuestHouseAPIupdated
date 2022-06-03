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
    public class RequestConfirmationsController : ControllerBase
    {
        private readonly DataContext _context;

        public RequestConfirmationsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/RequestConfirmations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestConfirmation>>> GetRequestConfirmation()
        {
          if (_context.RequestConfirmation == null)
          {
              return NotFound();
          }
            return await _context.RequestConfirmation.ToListAsync();
        }

        // GET: api/RequestConfirmations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<RequestConfirmation>>> GetRequestConfirmation(int? id)
        {


            var parameters = new[]
            {
                new SqlParameter("@0",id)
            };



            var result = await _context.RequestConfirmation.FromSqlRaw("Exec RoomConfirmation @0", parameters).ToListAsync();
            return result;




        }

        // PUT: api/RequestConfirmations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestConfirmation(int? id, RequestConfirmation requestConfirmation)
        {
            if (id != requestConfirmation.Reqnom)
            {
                return BadRequest();
            }

            _context.Entry(requestConfirmation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestConfirmationExists(id))
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

        // POST: api/RequestConfirmations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestConfirmation>> PostRequestConfirmation(RequestConfirmation requestConfirmation)
        {
          if (_context.RequestConfirmation == null)
          {
              return Problem("Entity set 'DataContext.RequestConfirmation'  is null.");
          }
            _context.RequestConfirmation.Add(requestConfirmation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestConfirmation", new { id = requestConfirmation.Reqnom }, requestConfirmation);
        }

        // DELETE: api/RequestConfirmations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestConfirmation(int? id)
        {
            if (_context.RequestConfirmation == null)
            {
                return NotFound();
            }
            var requestConfirmation = await _context.RequestConfirmation.FindAsync(id);
            if (requestConfirmation == null)
            {
                return NotFound();
            }

            _context.RequestConfirmation.Remove(requestConfirmation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestConfirmationExists(int? id)
        {
            return (_context.RequestConfirmation?.Any(e => e.Reqnom == id)).GetValueOrDefault();
        }
    }
}
