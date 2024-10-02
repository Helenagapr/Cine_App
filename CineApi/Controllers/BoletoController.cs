using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineApi.Data;
using CineApi.Models;
using AutoMapper;
using CineApi.DTO;

namespace CineApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoletoController : ControllerBase
    {
        private readonly ILogger<BoletoController> _logger;
        private readonly CineContext _bbdd;
        private readonly IMapper _mapper;

        public BoletoController(
            ILogger<BoletoController> logger,
            CineContext bbdd,
            IMapper mapper
        )
        {
            _logger = logger;
            _bbdd = bbdd;
            _mapper = mapper;
        }

        // GET: api/Boleto
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BoletoDTO>>> GetBoletos(
            [FromQuery] string? nombreCliente = null,
            [FromQuery] DateTime? fechaCompra = null,
            [FromQuery] string? tituloPelicula = null,
            [FromQuery] string? categoriaEntrada = null)
        {
            _logger.LogInformation("Obteniendo boletos"); 

            IQueryable<Boleto> query = _bbdd
                .Boletos
                .Include(b => b.cliente)
                .Include(b => b.pelicula)
                .Include(b => b.butaca)
                .Include(b => b.categoriaEntrada);
            
            if (!string.IsNullOrEmpty(nombreCliente)){
                query = query.Where(b => b.cliente.nombre.Contains(nombreCliente));
            }
            if (fechaCompra.HasValue){
                query = query.Where(b => b.fechaCompra.Date == fechaCompra.Value.Date);
            }
            if (!string.IsNullOrEmpty(tituloPelicula)){
                query = query.Where(b => b.pelicula.titulo.Contains(tituloPelicula));
            }
            if (!string.IsNullOrEmpty(categoriaEntrada)){
                query = query.Where(b => b.categoriaEntrada.nombre.Contains(categoriaEntrada));
            }

            var boletoList = await query.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<BoletoDTO>>(boletoList));
        }

        // GET: api/Boleto/5
        [HttpGet("{id:long}", Name = "GetBoleto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Boleto>> GetBoleto(long id)
        {   
            if (id <= 0) {
                _logger.LogError("Formato de ID incorrecto");
                return BadRequest("Formato de ID incorrecto");
            }

            var boleto = await _bbdd.Boletos
                .Include(b => b.cliente)
                .Include(b => b.pelicula)
                .Include(b => b.butaca)
                .Include(b => b.categoriaEntrada)
                .FirstOrDefaultAsync(b => b.id == id);

            if (boleto == null)
            {
                _logger.LogError("No se encontro el boleto con ID {id}");
                return NotFound("No se encontro el boleto con ID {id}");
            }

            return Ok(_mapper.Map<IEnumerable<BoletoDTO>>(boleto));
        }

        // PUT: api/Boleto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id: long}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutBoleto(long id, 
            [FromBody] BoletoDTO formBoleto )
        {
            if (id != formBoleto.id || formBoleto == null)
            {
                _logger.LogError("No existe la ID indicada");
                return BadRequest("No existe la ID indicada");
            }

            var existeixBoleto = await _bbdd.Boletos.AsNoTracking().FirstOrDefaultAsync(h => h.id == id);

            if(existeixBoleto == null){
                _logger.LogError("No existe ningun boleto con la ID indicada");
                return NotFound("No existe ningun boleto con la ID indicada");
            }

            Boleto boleto = _mapper.Map<Boleto>(formBoleto);


            var cliente = await _bbdd.Clientes.FindAsync(formBoleto.clienteId);

            var pelicula = await _bbdd.Peliculas.FindAsync(formBoleto.peliculaId);

            var butaca = await _bbdd.Butacas.FindAsync(formBoleto.butacaId);

            var categoriaEntrada = await _bbdd.CategoriaEntradas.FindAsync(formBoleto.categoriaEntradaId);


            if (cliente == null) return BadRequest("No existe ningún cliente con el indicado");
            
            if (pelicula == null) return BadRequest("No existe ninguna pelicula con el indicado");
            
            if (butaca == null) return BadRequest("No existe ninguna butaca con el indicado");
            
            if (categoriaEntrada == null) return BadRequest("No existe ninguna categoria con el indicado");

            _bbdd.Boletos.Update(boleto);
            await _bbdd.SaveChangesAsync();

            _logger.LogInformation("Boleto actualizado correctamente");
            return NoContent();
        }

        // POST: api/Boleto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CreateBoletoDTO>> PostBoleto(
            [FromBody] CreateBoletoDTO formBoleto
        )
        {
            if(!ModelState.IsValid) return BadRequest("El form es incorrecto: " + ModelState);

            var cliente = await _bbdd.Clientes.FindAsync(formBoleto.clienteId);

            var pelicula = await _bbdd.Peliculas.FindAsync(formBoleto.peliculaId);

            var butaca = await _bbdd.Butacas.FindAsync(formBoleto.butacaId);

            var categoriaEntrada = await _bbdd.CategoriaEntradas.FindAsync(formBoleto.categoriaEntradaId);

            if (cliente == null) return BadRequest("No existe ningún cliente con el indicado");
            

            if (pelicula == null) return BadRequest("No existe ninguna pelicula con el indicado");
            

            if (butaca == null) return BadRequest("No existe ninguna butaca con el indicado");
            

            if (categoriaEntrada == null) return BadRequest("No existe ninguna categoria con el indicado");
            
            Boleto boleto = _mapper.Map<Boleto>(formBoleto);
            boleto.clienteId = cliente.id;
            boleto.peliculaId = pelicula.id;
            boleto.butacaId = butaca.id;
            boleto.categoriaEntradaId = categoriaEntrada.id;

            await _bbdd.Boletos.AddAsync(boleto);
            await _bbdd.SaveChangesAsync();

            _logger.LogInformation("Boleto creado correctamente");
            
            return CreatedAtAction(nameof(GetBoleto), new { id = boleto.id }, formBoleto);
        }

        // DELETE: api/Boleto/5
        [HttpDelete("{id: long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBoleto(long id)
        {
            if(id <= 0){
                _logger.LogError("Formato d'ID incorrecte");
                return BadRequest("Formato d'ID incorrecte");
            }

            var boleto = await _bbdd.Boletos.FirstOrDefaultAsync(h => h.id == id);

            if (boleto == null)
            {
                _logger.LogError("ID de boleto no encontrado");
                return NotFound("ID de boleto no encontrado");
            }

            _bbdd.Boletos.Remove(boleto);
            await _bbdd.SaveChangesAsync();

            _logger.LogInformation("Boleto borrado correctamente");
            return NoContent();
        }
    }
}
