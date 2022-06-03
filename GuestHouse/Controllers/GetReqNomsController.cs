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
    public class GetReqNomsController : ControllerBase
    {
        private readonly DataContext _context;

        public GetReqNomsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GetReqNoms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetReqNom>>> GetGetReqNom()
        {
          if (_context.GetReqNom == null)
          {
              return NotFound();
          }
            return await _context.GetReqNom.FromSqlRaw("Exec FetchReqNom").ToListAsync();
        }

        // GET: api/GetReqNoms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetReqNom>> GetGetReqNom(int id)
        {
          if (_context.GetReqNom == null)
          {
              return NotFound();
          }
            var getReqNom = await _context.GetReqNom.FindAsync(id);

            if (getReqNom == null)
            {
                return NotFound();
            }

            return getReqNom;
        }

        // PUT: api/GetReqNoms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGetReqNom(int id, GetReqNom getReqNom)
        {
            if (id != getReqNom.Reqnom)
            {
                return BadRequest();
            }

            _context.Entry(getReqNom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GetReqNomExists(id))
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

        // POST: api/GetReqNoms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetReqNom>> PostGetReqNom(GetReqNom getReqNom)
        {
          if (_context.GetReqNom == null)
          {
              return Problem("Entity set 'DataContext.GetReqNom'  is null.");
          }
            _context.GetReqNom.Add(getReqNom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGetReqNom", new { id = getReqNom.Reqnom }, getReqNom);
        }

        // DELETE: api/GetReqNoms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGetReqNom(int id)
        {
            if (_context.GetReqNom == null)
            {
                return NotFound();
            }
            var getReqNom = await _context.GetReqNom.FindAsync(id);
            if (getReqNom == null)
            {
                return NotFound();
            }

            _context.GetReqNom.Remove(getReqNom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GetReqNomExists(int id)
        {
            return (_context.GetReqNom?.Any(e => e.Reqnom == id)).GetValueOrDefault();
        }
    }
}
