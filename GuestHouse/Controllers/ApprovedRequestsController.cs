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
    public class ApprovedRequestsController : ControllerBase
    {
        private readonly DataContext _context;

        public ApprovedRequestsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ApprovedRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApprovedRequest>>> GetApprovedRequests()
        {
            //return await _context.ApprovedRequests.ToListAsync();

            var str = "exec ApprovedRequest";
            return await _context.ApprovedRequests.FromSqlRaw(str).ToListAsync();
        }

        // GET: api/ApprovedRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApprovedRequest>> GetApprovedRequest(string id)
        {
            var approvedRequest = await _context.ApprovedRequests.FindAsync(id);

            if (approvedRequest == null)
            {
                return NotFound();
            }

            return approvedRequest;
        }

        // PUT: api/ApprovedRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApprovedRequest(string id, ApprovedRequest approvedRequest)
        {
            if (id != approvedRequest.ReqByTkt)
            {
                return BadRequest();
            }

            _context.Entry(approvedRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApprovedRequestExists(id))
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

        // POST: api/ApprovedRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ApprovedRequest>> PostApprovedRequest(ApprovedRequest approvedRequest)
        {
            _context.ApprovedRequests.Add(approvedRequest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ApprovedRequestExists(approvedRequest.ReqByTkt))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetApprovedRequest", new { id = approvedRequest.ReqByTkt }, approvedRequest);
        }

        // DELETE: api/ApprovedRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApprovedRequest(string id)
        {
            var approvedRequest = await _context.ApprovedRequests.FindAsync(id);
            if (approvedRequest == null)
            {
                return NotFound();
            }

            _context.ApprovedRequests.Remove(approvedRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ApprovedRequestExists(string id)
        {
            return _context.ApprovedRequests.Any(e => e.ReqByTkt == id);
        }
    }
}
