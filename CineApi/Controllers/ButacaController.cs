using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineApi.Data;
using CineApi.Models;
using CineApi.DTO;
using AutoMapper;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ButacaController : ControllerBase
    {
        private readonly CineContext _bbdd;
        private readonly ILogger<ButacaController> _logger;
        private readonly IMapper _mapper;

        public ButacaController(
            ILogger<ButacaController> logger,
            CineContext bbdd,
            IMapper mapper
        )
        {
            _logger = logger;
            _bbdd = bbdd;
            _mapper = mapper;
        }

        // GET: api/Butaca
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Butaca>>> GetButacas()
        {
            return await _context.Butacas.ToListAsync();
        }

        // GET: api/Butaca/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Butaca>> GetButaca(long id)
        {
            var butaca = await _context.Butacas.FindAsync(id);

            if (butaca == null)
            {
                return NotFound();
            }

            return butaca;
        }

        // PUT: api/Butaca/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutButaca(long id, Butaca butaca)
        {
            if (id != butaca.id)
            {
                return BadRequest();
            }

            _context.Entry(butaca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ButacaExists(id))
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

        // POST: api/Butaca
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Butaca>> PostButaca(Butaca butaca)
        {
            _context.Butacas.Add(butaca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetButaca", new { id = butaca.id }, butaca);
        }

        // DELETE: api/Butaca/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteButaca(long id)
        {
            var butaca = await _context.Butacas.FindAsync(id);
            if (butaca == null)
            {
                return NotFound();
            }

            _context.Butacas.Remove(butaca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ButacaExists(long id)
        {
            return _context.Butacas.Any(e => e.id == id);
        }
    }
}
