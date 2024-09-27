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
    public class FuncionController : ControllerBase
    {
        private readonly CineContext _context;

        public FuncionController(CineContext context)
        {
            _context = context;
        }

        // GET: api/Funcion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funcion>>> GetFunciones()
        {
            return await _context.Funciones.ToListAsync();
        }

        // GET: api/Funcion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcion>> GetFuncion(long id)
        {
            var funcion = await _context.Funciones.FindAsync(id);

            if (funcion == null)
            {
                return NotFound();
            }

            return funcion;
        }

        // PUT: api/Funcion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuncion(long id, Funcion funcion)
        {
            if (id != funcion.id)
            {
                return BadRequest();
            }

            _context.Entry(funcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuncionExists(id))
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

        // POST: api/Funcion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Funcion>> PostFuncion(Funcion funcion)
        {
            _context.Funciones.Add(funcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuncion", new { id = funcion.id }, funcion);
        }

        // DELETE: api/Funcion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuncion(long id)
        {
            var funcion = await _context.Funciones.FindAsync(id);
            if (funcion == null)
            {
                return NotFound();
            }

            _context.Funciones.Remove(funcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuncionExists(long id)
        {
            return _context.Funciones.Any(e => e.id == id);
        }
    }
}
