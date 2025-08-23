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
    public class ProveedoresController : ControllerBase
    {
        private readonly LBGeoDbContext _context;

        public ProveedoresController(LBGeoDbContext context)
        {
            _context = context;
        }

        // GET: api/Proveedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedores>>> GetProveedores()
        {
            return await _context.Proveedores.ToListAsync();
        }

        // GET: api/Proveedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedores>> GetProveedores(int id)
        {
            var proveedores = await _context.Proveedores.FindAsync(id);

            if (proveedores == null)
            {
                return NotFound();
            }

            return proveedores;
        }

        // PUT: api/Proveedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedores(int id, Proveedores proveedores)
        {
            if (id != proveedores.id_proveedor)
            {
                return BadRequest();
            }

            // Normalizar dirección antes de guardar
            proveedores.direccion = string.IsNullOrWhiteSpace(proveedores.direccion) ? "" : proveedores.direccion;
            _context.Entry(proveedores).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedoresExists(id))
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

        // POST: api/Proveedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Proveedores>> PostProveedores(Proveedores proveedores)
        {
            // Normalizar dirección antes de guardar
            proveedores.direccion = string.IsNullOrWhiteSpace(proveedores.direccion) ? "" : proveedores.direccion;
            _context.Proveedores.Add(proveedores);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProveedores", new { id = proveedores.id_proveedor }, proveedores);
        }

        // DELETE: api/Proveedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedores(int id)
        {
            var proveedores = await _context.Proveedores.FindAsync(id);
            if (proveedores == null)
            {
                return NotFound();
            }

            _context.Proveedores.Remove(proveedores);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProveedoresExists(int id)
        {
            return _context.Proveedores.Any(e => e.id_proveedor == id);
        }
    }
}
