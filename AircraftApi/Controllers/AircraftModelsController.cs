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
    public class AircraftModelsController : ControllerBase
    {
        private readonly AircraftDbContext _context;

        public AircraftModelsController(AircraftDbContext context)
        {
            _context = context;
        }

        // GET: api/AircraftModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AircraftModel>>> GetAircraftModels()
        {
          if (_context.AircraftModels == null)
          {
              return NotFound();
          }
            return await _context.AircraftModels.ToListAsync();
        }

        // GET: api/AircraftModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AircraftModel>> GetAircraftModel(int id)
        {
          if (_context.AircraftModels == null)
          {
              return NotFound();
          }
            var aircraftModel = await _context.AircraftModels.FindAsync(id);

            if (aircraftModel == null)
            {
                return NotFound();
            }

            return aircraftModel;
        }

        // PUT: api/AircraftModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAircraftModel(int id, AircraftModel aircraftModel)
        {
            if (id != aircraftModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(aircraftModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AircraftModelExists(id))
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

        // POST: api/AircraftModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AircraftModel>> PostAircraftModel(AircraftModel aircraftModel)
        {
          if (_context.AircraftModels == null)
          {
              return Problem("Entity set 'AircraftDbContext.AircraftModels'  is null.");
          }
          // return conflict if the aircraft model already exists by name
          if (_context.AircraftModels.Any(am => am.Name == aircraftModel.Name))
            {
                return Conflict();
            }

            _context.AircraftModels.Add(aircraftModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAircraftModel", new { id = aircraftModel.Id }, aircraftModel);
        }

        // DELETE: api/AircraftModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraftModel(int id)
        {
            if (_context.AircraftModels == null)
            {
                return NotFound();
            }
            var aircraftModel = await _context.AircraftModels.FindAsync(id);
            if (aircraftModel == null)
            {
                return NotFound();
            }

            _context.AircraftModels.Remove(aircraftModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AircraftModelExists(int id)
        {
            return (_context.AircraftModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
