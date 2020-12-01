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
    public class BagWithParcelsController : ControllerBase
    {
        private readonly REST_APIContext _context;

        public BagWithParcelsController(REST_APIContext context)
        {
            _context = context;
        }

        // GET: api/BagWithParcels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BagWithParcels>>> GetBagWithParcels()
        {
            return await _context.BagWithParcels.ToListAsync();
        }

        // GET: api/BagWithParcels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BagWithParcels>> GetBagWithParcels(int id)
        {
            var bagWithParcels = await _context.BagWithParcels.FindAsync(id);

            if (bagWithParcels == null)
            {
                return NotFound();
            }

            return bagWithParcels;
        }

        // PUT: api/BagWithParcels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBagWithParcels(int id, BagWithParcels bagWithParcels)
        {
            if (id != bagWithParcels.Id)
            {
                return BadRequest();
            }

            _context.Entry(bagWithParcels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagWithParcelsExists(id))
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

        // POST: api/BagWithParcels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BagWithParcels>> PostBagWithParcels(BagWithParcels bagWithParcels)
        {
            _context.BagWithParcels.Add(bagWithParcels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBagWithParcels", new { id = bagWithParcels.Id }, bagWithParcels);
        }

        // DELETE: api/BagWithParcels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBagWithParcels(int id)
        {
            var bagWithParcels = await _context.BagWithParcels.FindAsync(id);
            if (bagWithParcels == null)
            {
                return NotFound();
            }

            _context.BagWithParcels.Remove(bagWithParcels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BagWithParcelsExists(int id)
        {
            return _context.BagWithParcels.Any(e => e.Id == id);
        }
    }
}
