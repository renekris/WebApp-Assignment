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
    public class BagParcelsController : ControllerBase
    {
        private readonly REST_APIContext _context;

        public BagParcelsController(REST_APIContext context)
        {
            _context = context;
        }

        // GET: api/BagParcels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BagParcels>>> GetBagParcels()
        {
            return await _context.BagParcels.ToListAsync();
        }

        // GET: api/BagParcels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BagParcels>> GetBagParcels(Guid id)
        {
            var bagParcels = await _context.BagParcels.FindAsync(id);

            if (bagParcels == null)
            {
                return NotFound();
            }

            return bagParcels;
        }

        // PUT: api/BagParcels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBagParcels(Guid id, BagParcels bagParcels)
        {
            if (id != bagParcels.Id)
            {
                return BadRequest();
            }

            _context.Entry(bagParcels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagParcelsExists(id))
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

        // POST: api/BagParcels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BagParcels>> PostBagParcels(BagParcels bagParcels)
        {
            _context.BagParcels.Add(bagParcels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBagParcels", new { id = bagParcels.Id }, bagParcels);
        }

        // DELETE: api/BagParcels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBagParcels(Guid id)
        {
            var bagParcels = await _context.BagParcels.FindAsync(id);
            if (bagParcels == null)
            {
                return NotFound();
            }

            _context.BagParcels.Remove(bagParcels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BagParcelsExists(Guid id)
        {
            return _context.BagParcels.Any(e => e.Id == id);
        }
    }
}
