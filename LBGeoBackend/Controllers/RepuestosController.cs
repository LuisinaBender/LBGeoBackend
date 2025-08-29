using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LBGeoBackend.DataContext;
using LBGeoBackend.Models;

namespace LBGeoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepuestosController : ControllerBase
    {
        private readonly LBGeoDbContext _context;

        public RepuestosController(LBGeoDbContext context)
        {
            _context = context;
        }

        // GET: api/Repuestos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repuestos>>> GetRepuestos()
        {
            return await _context.Repuestos.ToListAsync();
        }

        // GET: api/Repuestos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Repuestos>> GetRepuestos(int id)
        {
            var repuestos = await _context.Repuestos.FindAsync(id);

            if (repuestos == null)
            {
                return NotFound();
            }

            return repuestos;
        }

        // PUT: api/Repuestos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepuestos(int id, Repuestos repuestos)
        {
            if (id != repuestos.id_repuesto)
            {
                return BadRequest();
            }

            _context.Entry(repuestos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepuestosExists(id))
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

        // POST: api/Repuestos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPost]
        public async Task<ActionResult<Repuestos>> PostRepuestos(Repuestos repuestos)
        {
            // Solo necesitas los IDs, no los objetos completos
            _context.Repuestos.Add(repuestos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepuestos", new { id = repuestos.id_repuesto }, repuestos);
        }

        // DELETE: api/Repuestos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepuestos(int id)
        {
            var repuestos = await _context.Repuestos.FindAsync(id);
            if (repuestos == null)
            {
                return NotFound();
            }

            _context.Repuestos.Remove(repuestos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepuestosExists(int id)
        {
            return _context.Repuestos.Any(e => e.id_repuesto == id);
        }
    }
}
