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
    public class AdminDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public AdminDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/AdminDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDetails>>> GetAdminDetails()
        {
            return await _context.AdminDetails.ToListAsync();
        }

        // GET: api/AdminDetails/5
        [HttpGet("{LName}")]
        public async Task<ActionResult<IEnumerable<AdminDetails>>> GetAdminDetails(string LName)
        {
            //var adminDetails = await _context.AdminDetails.FindAsync(id);

            //if (adminDetails == null)
            //{
            //  return NotFound();
            //}

            var parameters = new[]
            {
                new SqlParameter("@0",LName)
            };

            return await _context.AdminDetails.FromSqlRaw("Exec Admin_Details @0",parameters).ToListAsync();
        }

        // PUT: api/AdminDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAdminDetails(string id, AdminDetails adminDetails)
        //{
        //    if (id != adminDetails.LName)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(adminDetails).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AdminDetailsExists(id))
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

        // POST: api/AdminDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<AdminDetails>> PostAdminDetails(AdminDetails adminDetails)
        //{
        //    _context.AdminDetails.Add(adminDetails);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (AdminDetailsExists(adminDetails.LName))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetAdminDetails", new { id = adminDetails.LName }, adminDetails);
        //}

        

        
    }
}
