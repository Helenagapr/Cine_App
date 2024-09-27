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
    public class CategoriaEntradaController : ControllerBase
    {
        private readonly CineContext _context;

        public CategoriaEntradaController(CineContext context)
        {
            _context = context;
        }

        // GET: api/CategoriaEntrada
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaEntrada>>> GetCategoriaEntradas()
        {
            return await _context.CategoriaEntradas.ToListAsync();
        }

        // GET: api/CategoriaEntrada/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaEntrada>> GetCategoriaEntrada(long id)
        {
            var categoriaEntrada = await _context.CategoriaEntradas.FindAsync(id);

            if (categoriaEntrada == null)
            {
                return NotFound();
            }

            return categoriaEntrada;
        }

        // PUT: api/CategoriaEntrada/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaEntrada(long id, CategoriaEntrada categoriaEntrada)
        {
            if (id != categoriaEntrada.id)
            {
                return BadRequest();
            }

            _context.Entry(categoriaEntrada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaEntradaExists(id))
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

        // POST: api/CategoriaEntrada
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaEntrada>> PostCategoriaEntrada(CategoriaEntrada categoriaEntrada)
        {
            _context.CategoriaEntradas.Add(categoriaEntrada);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoriaEntrada", new { id = categoriaEntrada.id }, categoriaEntrada);
        }

        // DELETE: api/CategoriaEntrada/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaEntrada(long id)
        {
            var categoriaEntrada = await _context.CategoriaEntradas.FindAsync(id);
            if (categoriaEntrada == null)
            {
                return NotFound();
            }

            _context.CategoriaEntradas.Remove(categoriaEntrada);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaEntradaExists(long id)
        {
            return _context.CategoriaEntradas.Any(e => e.id == id);
        }
    }
}
