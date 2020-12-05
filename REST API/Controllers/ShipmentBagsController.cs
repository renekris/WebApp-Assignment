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
    public class ShipmentBagsController : ControllerBase
    {
        private readonly REST_APIContext _context;

        public ShipmentBagsController(REST_APIContext context)
        {
            _context = context;
        }

        // GET: api/ShipmentBags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipmentBags>>> GetShipmentBags()
        {
            return await _context.ShipmentBags.ToListAsync();
        }

        // GET: api/ShipmentBags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShipmentBags>> GetShipmentBags(Guid id)
        {
            var shipmentBags = await _context.ShipmentBags.FindAsync(id);

            if (shipmentBags == null)
            {
                return NotFound();
            }

            return shipmentBags;
        }

        // PUT: api/ShipmentBags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipmentBags(Guid id, ShipmentBags shipmentBags)
        {
            if (id != shipmentBags.Id)
            {
                return BadRequest();
            }

            _context.Entry(shipmentBags).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentBagsExists(id))
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

        // POST: api/ShipmentBags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ShipmentBags>> PostShipmentBags(ShipmentBags shipmentBags)
        {
            _context.ShipmentBags.Add(shipmentBags);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipmentBags", new { id = shipmentBags.Id }, shipmentBags);
        }

        // DELETE: api/ShipmentBags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipmentBags(Guid id)
        {
            var shipmentBags = await _context.ShipmentBags.FindAsync(id);
            if (shipmentBags == null)
            {
                return NotFound();
            }

            _context.ShipmentBags.Remove(shipmentBags);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShipmentBagsExists(Guid id)
        {
            return _context.ShipmentBags.Any(e => e.Id == id);
        }
    }
}
