using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API.Data;
using REST_API.Models;

namespace REST_API.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class BagWithLettersController : ControllerBase
    {
        private readonly REST_APIContext _context;

        public BagWithLettersController(REST_APIContext context)
        {
            _context = context;
        }

        // GET: api/BagWithLetters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BagWithLetters>>> GetBagWithLetters()
        {
            return await _context.BagWithLetters.ToListAsync();
        }

        // GET: api/BagWithLetters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BagWithLetters>> GetBagWithLetters(int id)
        {
            var bagWithLetters = await _context.BagWithLetters.FindAsync(id);

            if (bagWithLetters == null)
            {
                return NotFound();
            }

            return bagWithLetters;
        }

        // PUT: api/BagWithLetters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBagWithLetters(int id, BagWithLetters bagWithLetters)
        {
            if (id != bagWithLetters.Id)
            {
                return BadRequest();
            }

            _context.Entry(bagWithLetters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagWithLettersExists(id))
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

        // POST: api/BagWithLetters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BagWithLetters>> PostBagWithLetters(BagWithLetters bagWithLetters)
        {
            _context.BagWithLetters.Add(bagWithLetters);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBagWithLetters", new { id = bagWithLetters.Id }, bagWithLetters);
        }

        // DELETE: api/BagWithLetters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBagWithLetters(int id)
        {
            var bagWithLetters = await _context.BagWithLetters.FindAsync(id);
            if (bagWithLetters == null)
            {
                return NotFound();
            }

            _context.BagWithLetters.Remove(bagWithLetters);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BagWithLettersExists(int id)
        {
            return _context.BagWithLetters.Any(e => e.Id == id);
        }
    }
}
