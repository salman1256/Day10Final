using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PassportAPI.Data;
using PassportAPI.Models;

namespace PassportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassportsController : ControllerBase
    {
        private readonly PassportDbContext _context;

        public PassportsController(PassportDbContext context)
        {
            _context = context;
        }

        // GET: api/Passports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passport>>> GetPassport()
        {
          if (_context.Passport == null)
          {
              return NotFound();
          }
            return await _context.Passport.ToListAsync();
        }

        // GET: api/Passports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passport>> GetPassport(int id)
        {
          if (_context.Passport == null)
          {
              return NotFound();
          }
            var passport = await _context.Passport.FindAsync(id);

            if (passport == null)
            {
                return NotFound();
            }

            return passport;
        }

        // PUT: api/Passports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassport(int id, Passport passport)
        {
            if (id != passport.Id)
            {
                return BadRequest();
            }

            _context.Entry(passport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassportExists(id))
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

        // POST: api/Passports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passport>> PostPassport(Passport passport)
        {
          if (_context.Passport == null)
          {
              return Problem("Entity set 'PassportDbContext.Passport'  is null.");
          }
            _context.Passport.Add(passport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassport", new { id = passport.Id }, passport);
        }

        // DELETE: api/Passports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassport(int id)
        {
            if (_context.Passport == null)
            {
                return NotFound();
            }
            var passport = await _context.Passport.FindAsync(id);
            if (passport == null)
            {
                return NotFound();
            }

            _context.Passport.Remove(passport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassportExists(int id)
        {
            return (_context.Passport?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
