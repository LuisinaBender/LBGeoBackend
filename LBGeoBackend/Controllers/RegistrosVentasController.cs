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
    public class RegistrosVentasController : ControllerBase
    {
        private readonly LBGeoDbContext _context;

        public RegistrosVentasController(LBGeoDbContext context)
        {
            _context = context;
        }

        // GET: api/RegistrosVentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrosVentas>>> GetRegistrosVentas()
        {
            return await _context.RegistrosVentas.ToListAsync();
        }

        // GET: api/RegistrosVentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrosVentas>> GetRegistrosVentas(int id)
        {
            var registrosVentas = await _context.RegistrosVentas.FindAsync(id);

            if (registrosVentas == null)
            {
                return NotFound();
            }

            return registrosVentas;
        }

        // PUT: api/RegistrosVentas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistrosVentas(int id, RegistrosVentas registrosVentas)
        {
            if (id != registrosVentas.id_registro_venta)
            {
                return BadRequest();
            }

            _context.Entry(registrosVentas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrosVentasExists(id))
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

        // POST: api/RegistrosVentas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegistrosVentas>> PostRegistrosVentas(RegistrosVentas registrosVentas)
        {
            _context.RegistrosVentas.Add(registrosVentas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistrosVentas", new { id = registrosVentas.id_registro_venta }, registrosVentas);
        }

        // DELETE: api/RegistrosVentas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistrosVentas(int id)
        {
            var registrosVentas = await _context.RegistrosVentas.FindAsync(id);
            if (registrosVentas == null)
            {
                return NotFound();
            }

            _context.RegistrosVentas.Remove(registrosVentas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistrosVentasExists(int id)
        {
            return _context.RegistrosVentas.Any(e => e.id_registro_venta == id);
        }
    }
}
