using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carriers.Api.Models;

namespace Carriers.Api.Controllers
{
    [Route("carrier-groups")]
    [ApiController]
    public class CarrierGroupsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CarrierGroupsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/CarrierGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarrierGroup>>> GetCarrierGroup()
        {
            return await _context.CarrierGroup.ToListAsync();
        }

        // GET: api/CarrierGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarrierGroup>> GetCarrierGroup(int id)
        {
          if (_context.CarrierGroup == null)
          {
              return NotFound();
          }
            var carrierGroup = await _context.CarrierGroup.FindAsync(id);

            if (carrierGroup == null)
            {
                return NotFound();
            }

            return carrierGroup;
        }

        // PUT: api/CarrierGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrierGroup(int id, CarrierGroup carrierGroup)
        {
            if (id != carrierGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(carrierGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrierGroupExists(id))
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

        // POST: api/CarrierGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CarrierGroup>> PostCarrierGroup(CarrierGroup carrierGroup)
        {
          if (_context.CarrierGroup == null)
          {
              return Problem("Entity set 'ApplicationContext.CarrierGroup'  is null.");
          }
            _context.CarrierGroup.Add(carrierGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrierGroup", new { id = carrierGroup.Id }, carrierGroup);
        }

        // DELETE: api/CarrierGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrierGroup(int id)
        {
            if (_context.CarrierGroup == null)
            {
                return NotFound();
            }
            var carrierGroup = await _context.CarrierGroup.FindAsync(id);
            if (carrierGroup == null)
            {
                return NotFound();
            }

            _context.CarrierGroup.Remove(carrierGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarrierGroupExists(int id)
        {
            return (_context.CarrierGroup?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
