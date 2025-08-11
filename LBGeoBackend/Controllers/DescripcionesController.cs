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
    public class DescripcionesController : ControllerBase
    {
        private readonly LBGeoDbContext _context;

        public DescripcionesController(LBGeoDbContext context)
        {
            _context = context;
        }

        // GET: api/Descripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Descripciones>>> GetDescripciones()
        {
            return await _context.Descripciones.ToListAsync();
        }

        // GET: api/Descripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Descripciones>> GetDescripciones(int id)
        {
            var descripciones = await _context.Descripciones.FindAsync(id);

            if (descripciones == null)
            {
                return NotFound();
            }

            return descripciones;
        }

        // PUT: api/Descripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescripciones(int id, Descripciones descripciones)
        {
            if (id != descripciones.id_descripcion)
            {
                return BadRequest();
            }

            _context.Entry(descripciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescripcionesExists(id))
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

        // POST: api/Descripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Descripciones>> PostDescripciones(Descripciones descripciones)
        {
            _context.Descripciones.Add(descripciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDescripciones", new { id = descripciones.id_descripcion }, descripciones);
        }

        // DELETE: api/Descripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDescripciones(int id)
        {
            var descripciones = await _context.Descripciones.FindAsync(id);
            if (descripciones == null)
            {
                return NotFound();
            }

            _context.Descripciones.Remove(descripciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DescripcionesExists(int id)
        {
            return _context.Descripciones.Any(e => e.id_descripcion == id);
        }
    }
}
