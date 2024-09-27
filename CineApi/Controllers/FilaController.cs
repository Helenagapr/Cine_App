using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineApi.Data;
using CineApi.Models;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilaController : ControllerBase
    {
        private readonly CineContext _context;

        public FilaController(CineContext context)
        {
            _context = context;
        }

        // GET: api/Fila
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fila>>> GetFilas()
        {
            return await _context.Filas.ToListAsync();
        }

        // GET: api/Fila/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fila>> GetFila(long id)
        {
            var fila = await _context.Filas.FindAsync(id);

            if (fila == null)
            {
                return NotFound();
            }

            return fila;
        }

        // PUT: api/Fila/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFila(long id, Fila fila)
        {
            if (id != fila.id)
            {
                return BadRequest();
            }

            _context.Entry(fila).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilaExists(id))
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

        // POST: api/Fila
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fila>> PostFila(Fila fila)
        {
            _context.Filas.Add(fila);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFila", new { id = fila.id }, fila);
        }

        // DELETE: api/Fila/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFila(long id)
        {
            var fila = await _context.Filas.FindAsync(id);
            if (fila == null)
            {
                return NotFound();
            }

            _context.Filas.Remove(fila);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilaExists(long id)
        {
            return _context.Filas.Any(e => e.id == id);
        }
    }
}
