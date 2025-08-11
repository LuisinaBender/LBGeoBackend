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
    public class EquivalenciasController : ControllerBase
    {
        private readonly LBGeoDbContext _context;

        public EquivalenciasController(LBGeoDbContext context)
        {
            _context = context;
        }

        // GET: api/Equivalencias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Equivalencias>>> GetEquivalencias()
        {
            return await _context.Equivalencias.ToListAsync();
        }

        // GET: api/Equivalencias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Equivalencias>> GetEquivalencias(int id)
        {
            var equivalencias = await _context.Equivalencias.FindAsync(id);

            if (equivalencias == null)
            {
                return NotFound();
            }

            return equivalencias;
        }

        // PUT: api/Equivalencias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEquivalencias(int id, Equivalencias equivalencias)
        {
            if (id != equivalencias.id_equivalencia)
            {
                return BadRequest();
            }

            _context.Entry(equivalencias).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EquivalenciasExists(id))
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

        // POST: api/Equivalencias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Equivalencias>> PostEquivalencias(Equivalencias equivalencias)
        {
            _context.Equivalencias.Add(equivalencias);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEquivalencias", new { id = equivalencias.id_equivalencia }, equivalencias);
        }

        // DELETE: api/Equivalencias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquivalencias(int id)
        {
            var equivalencias = await _context.Equivalencias.FindAsync(id);
            if (equivalencias == null)
            {
                return NotFound();
            }

            _context.Equivalencias.Remove(equivalencias);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EquivalenciasExists(int id)
        {
            return _context.Equivalencias.Any(e => e.id_equivalencia == id);
        }
    }
}
