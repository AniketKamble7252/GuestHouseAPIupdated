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

namespace GuestHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly DataContext _context;

        public StatusController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Status>> GetStatus(string id)
        //{
        //    var status = await _context.Statuses.FindAsync(id);

        //    if (status == null)
        //    {
        //        return NotFound();
        //    }

        //    return status;
        //}
        public async Task<ActionResult<IEnumerable<Status>>> GetStatus(string id)
        {


            var parameters = new[]
            {
                new SqlParameter("@0",id)
            };
            return await _context.Statuses.FromSqlRaw("Exec Status @0", parameters).ToListAsync();
        }

        // PUT: api/Status/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStatus(string id, Status status)
        //{
        //    if (id != status.ReqByTkt)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(status).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StatusExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Status
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Status>> PostStatus(Status status)
        //{
        //    _context.Statuses.Add(status);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (StatusExists(status.ReqByTkt))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetStatus", new { id = status.ReqByTkt }, status);
        //}

        //// DELETE: api/Status/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteStatus(string id)
        //{
        //    var status = await _context.Statuses.FindAsync(id);
        //    if (status == null)
        //    {
        //        return NotFound();
            }

        //    _context.Statuses.Remove(status);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool StatusExists(string id)
        //{
        //    return _context.Statuses.Any(e => e.ReqByTkt == id);
        //}
    }

