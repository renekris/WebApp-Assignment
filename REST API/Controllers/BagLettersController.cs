using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API.Data;
using REST_API.Models;

namespace REST_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BagLettersController : ControllerBase
    {
        private readonly REST_APIContext _context;

        public BagLettersController(REST_APIContext context)
        {
            _context = context;
        }

        // GET: api/BagLetters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BagLetters>>> GetBagLetters()
        {
            return await _context.BagLetters.ToListAsync();
        }

        // GET: api/BagLetters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BagLetters>> GetBagLetters(Guid id)
        {
            var bagLetters = await _context.BagLetters.FindAsync(id);

            if (bagLetters == null)
            {
                return NotFound();
            }

            return bagLetters;
        }

        // PUT: api/BagLetters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBagLetters(Guid id, BagLetters bagLetters)
        {
            if (id != bagLetters.Id)
            {
                return BadRequest();
            }

            _context.Entry(bagLetters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagLettersExists(id))
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

        // POST: api/BagLetters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BagLetters>> PostBagLetters(BagLetters bagLetters)
        {
            _context.BagLetters.Add(bagLetters);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBagLetters", new { id = bagLetters.Id }, bagLetters);
        }

        // DELETE: api/BagLetters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBagLetters(Guid id)
        {
            var bagLetters = await _context.BagLetters.FindAsync(id);
            if (bagLetters == null)
            {
                return NotFound();
            }

            _context.BagLetters.Remove(bagLetters);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BagLettersExists(Guid id)
        {
            return _context.BagLetters.Any(e => e.Id == id);
        }
    }
}
