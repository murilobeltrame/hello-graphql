using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Carriers.Api.Models;

namespace Carriers.Api.Controllers
{
    [Route("carriers")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CarriersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Carriers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrier>>> GetCarrier()
        {
            return await _context.Carrier.ToListAsync();
        }

        // GET: api/Carriers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrier>> GetCarrier(int id)
        {
          if (_context.Carrier == null)
          {
              return NotFound();
          }
            var carrier = await _context.Carrier.FindAsync(id);

            if (carrier == null)
            {
                return NotFound();
            }

            return carrier;
        }

        // PUT: api/Carriers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrier(int id, Carrier carrier)
        {
            if (id != carrier.Id)
            {
                return BadRequest();
            }

            _context.Entry(carrier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarrierExists(id))
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

        // POST: api/Carriers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carrier>> PostCarrier(Carrier carrier)
        {
          if (_context.Carrier == null)
          {
              return Problem("Entity set 'ApplicationContext.Carrier'  is null.");
          }
            _context.Carrier.Add(carrier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrier", new { id = carrier.Id }, carrier);
        }

        // DELETE: api/Carriers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrier(int id)
        {
            if (_context.Carrier == null)
            {
                return NotFound();
            }
            var carrier = await _context.Carrier.FindAsync(id);
            if (carrier == null)
            {
                return NotFound();
            }

            _context.Carrier.Remove(carrier);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarrierExists(int id)
        {
            return (_context.Carrier?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
