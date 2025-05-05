using LocadoraCarros.Connection;
using LocadoraCarros.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LocadoraCarros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CarroController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carro>>> Get()
        {
            return await _context.Carros.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<Carro>>> GetById(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            if(carro == null)return NotFound();
            return await _context.Carros.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Carro>> Post(Carro carro)
        {
            _context.Carros.Add(carro);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = carro.Id }, carro);
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, Carro carro)
        {
            if (id != carro.Id) return BadRequest();
            _context.Entry(carro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            var carro = await _context.Carros.FindAsync(id);
            if (carro == null) return NotFound();

            _context.Carros.Remove(carro);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
