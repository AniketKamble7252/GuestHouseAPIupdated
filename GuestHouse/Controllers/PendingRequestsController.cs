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

namespace GuestHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PendingRequestsController : ControllerBase
    {
        private readonly DataContext _context;

        public PendingRequestsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/PendingRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PendingRequest>>> GetPendingRequests()
        {
            //return await _context.PendingRequests.ToListAsync();
            var str = "exec PendingRequest";
            return await _context.PendingRequests.FromSqlRaw(str).ToListAsync();

        }

        

        // GET: api/PendingRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PendingRequest>> GetPendingRequest(string id)
        {
            var pendingRequest = await _context.PendingRequests.FindAsync(id);

            if (pendingRequest == null)
            {
                return NotFound();
            }

            return pendingRequest;
        }

        // PUT: api/PendingRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPendingRequest(string id, PendingRequest pendingRequest)
        {
            if (id != pendingRequest.ReqByTkt)
            {
                return BadRequest();
            }

            _context.Entry(pendingRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PendingRequestExists(id))
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

        // POST: api/PendingRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PendingRequest>> PostPendingRequest(PendingRequest pendingRequest)
        {
            _context.PendingRequests.Add(pendingRequest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PendingRequestExists(pendingRequest.ReqByTkt))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPendingRequest", new { id = pendingRequest.ReqByTkt }, pendingRequest);
        }

        // DELETE: api/PendingRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePendingRequest(string id)
        {
            var pendingRequest = await _context.PendingRequests.FindAsync(id);
            if (pendingRequest == null)
            {
                return NotFound();
            }

            _context.PendingRequests.Remove(pendingRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PendingRequestExists(string id)
        {
            return _context.PendingRequests.Any(e => e.ReqByTkt == id);
        }
    }
}
