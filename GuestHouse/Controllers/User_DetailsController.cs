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
    public class User_DetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public User_DetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/User_Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User_Details>>> GetUser_Details()
        {
            return await _context.User_Details.ToListAsync();
        }

        // GET: api/User_Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User_Details>>>GetUser_Details(string id)
        {
          

            var parameters = new[]
            {
                new SqlParameter("@0",id)
            };

            return await _context.User_Details.FromSqlRaw("Exec User_Details @0", parameters).ToListAsync();
        }

        // PUT: api/User_Details/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser_Details(string id, User_Details user_Details)
        //{
        //    if (id != user_Details.TKTNO)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user_Details).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!User_DetailsExists(id))
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

        // POST: api/User_Details
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<User_Details>> PostUser_Details(User_Details user_Details)
        //{
        //    _context.User_Details.Add(user_Details);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (User_DetailsExists(user_Details.TKTNO))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetUser_Details", new { id = user_Details.TKTNO }, user_Details);
        //}

        // DELETE: api/User_Details/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUser_Details(string id)
        //{
        //    var user_Details = await _context.User_Details.FindAsync(id);
        //    if (user_Details == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.User_Details.Remove(user_Details);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool User_DetailsExists(string id)
        //{
        //    return _context.User_Details.Any(e => e.TKTNO == id);
        //}
    }
}
