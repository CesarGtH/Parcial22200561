using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial20240222200561DB.Infraestructure.Data;

namespace Parcial20240222200561DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicController : ControllerBase
    {
        private readonly Parcial20240222200561DbContext _context;

        public MechanicController(Parcial20240222200561DbContext context)
        {
            _context = context;
        }

        // GET: api/Mechanic
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mechanic>>> GetMechanic()
        {
            return await _context.Mechanic.ToListAsync();
        }

        // GET: api/Mechanic/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mechanic>> GetMechanic(int id)
        {
            var mechanic = await _context.Mechanic.FindAsync(id);

            if (mechanic == null)
            {
                return NotFound();
            }

            return mechanic;
        }

        // PUT: api/Mechanic/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMechanic(int id, Mechanic mechanic)
        {
            if (id != mechanic.Id)
            {
                return BadRequest();
            }

            _context.Entry(mechanic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MechanicExists(id))
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

        // POST: api/Mechanic
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mechanic>> PostMechanic(Mechanic mechanic)
        {
            _context.Mechanic.Add(mechanic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMechanic", new { id = mechanic.Id }, mechanic);
        }

        // DELETE: api/Mechanic/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMechanic(int id)
        {
            var mechanic = await _context.Mechanic.FindAsync(id);
            if (mechanic == null)
            {
                return NotFound();
            }

            _context.Mechanic.Remove(mechanic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MechanicExists(int id)
        {
            return _context.Mechanic.Any(e => e.Id == id);
        }
    }
}
