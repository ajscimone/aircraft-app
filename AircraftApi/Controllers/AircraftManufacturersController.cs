using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AircraftApi.Data;
using AircraftApi.Models.Domain;

namespace AircraftApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftManufacturersController : ControllerBase
    {
        private readonly AircraftDbContext _context;

        public AircraftManufacturersController(AircraftDbContext context)
        {
            _context = context;
        }

        // GET: api/AircraftManufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AircraftManufacturer>>> GetAircraftManufacturers()
        {
          if (_context.AircraftManufacturers == null)
          {
              return NotFound();
          }
            return await _context.AircraftManufacturers.ToListAsync();
        }

        // GET: api/AircraftManufacturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AircraftManufacturer>> GetAircraftManufacturer(int id)
        {
          if (_context.AircraftManufacturers == null)
          {
              return NotFound();
          }
            var aircraftManufacturer = await _context.AircraftManufacturers.FindAsync(id);

            if (aircraftManufacturer == null)
            {
                return NotFound();
            }

            return aircraftManufacturer;
        }

        // PUT: api/AircraftManufacturers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAircraftManufacturer(int id, AircraftManufacturer aircraftManufacturer)
        {
            if (id != aircraftManufacturer.Id)
            {
                return BadRequest();
            }

            _context.Entry(aircraftManufacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftManufacturerExists(id))
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

        // POST: api/AircraftManufacturers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AircraftManufacturer>> PostAircraftManufacturer(AircraftManufacturer aircraftManufacturer)
        {
            if (_context.AircraftManufacturers == null)
            {
                return Problem("Entity set 'AircraftDbContext.AircraftManufacturers'  is null.");
            }

            if (AircraftManufacturerExists(aircraftManufacturer.Id) || AircraftManufacturerExists(aircraftManufacturer.Name))
            {
                return Conflict("AircraftManufacturer Id or Name Exists");
            }

            _context.AircraftManufacturers.Add(aircraftManufacturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAircraftManufacturer", new { id = aircraftManufacturer.Id }, aircraftManufacturer);
        }

        // DELETE: api/AircraftManufacturers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraftManufacturer(int id)
        {
            if (_context.AircraftManufacturers == null)
            {
                return NotFound();
            }
            var aircraftManufacturer = await _context.AircraftManufacturers.FindAsync(id);
            if (aircraftManufacturer == null)
            {
                return NotFound();
            }

            _context.AircraftManufacturers.Remove(aircraftManufacturer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AircraftManufacturerExists(int id)
        {
            return (_context.AircraftManufacturers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private bool AircraftManufacturerExists(string name)
        {
            return (_context.AircraftManufacturers?.Any(e => e.Name == name)).GetValueOrDefault();
        }
    }
}
