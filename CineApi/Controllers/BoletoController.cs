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
    public class BoletoController : ControllerBase
    {
        private readonly CineContext _context;

        public BoletoController(CineContext context)
        {
            _context = context;
        }

        // GET: api/Boleto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Boleto>>> GetBoletos()
        {
            return await _context.Boletos.ToListAsync();
        }

        // GET: api/Boleto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Boleto>> GetBoleto(long id)
        {
            var boleto = await _context.Boletos.FindAsync(id);

            if (boleto == null)
            {
                return NotFound();
            }

            return boleto;
        }

        // PUT: api/Boleto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoleto(long id, Boleto boleto)
        {
            if (id != boleto.id)
            {
                return BadRequest();
            }

            _context.Entry(boleto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoletoExists(id))
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

        // POST: api/Boleto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Boleto>> PostBoleto(Boleto boleto)
        {
            _context.Boletos.Add(boleto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBoleto), new { id = boleto.id }, boleto);
        }

        // DELETE: api/Boleto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoleto(long id)
        {
            var boleto = await _context.Boletos.FindAsync(id);
            if (boleto == null)
            {
                return NotFound();
            }

            _context.Boletos.Remove(boleto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoletoExists(long id)
        {
            return _context.Boletos.Any(e => e.id == id);
        }
    }
}
