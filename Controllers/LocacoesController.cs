using LocadoraCarros.Connection;
using LocadoraCarros.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraCarros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacoesController : ControllerBase
    {

        private readonly AppDbContext _context;

        public LocacoesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("calcular")]
        public async Task<ActionResult<LocacaoResponse>> CalcularLocacao(LocacaoRequest request)
        {
            var carro = await _context.Carros.FindAsync(request.CarroId);
            if(carro == null)
            {
                return NotFound();
            }

            int dias = (request.DataFim - request.DataInicio).Days;

            double subtotal = dias * carro.ValorDiaria;
            double desconto = 0;

            if (dias >= 7)
            {
                desconto = 0.10;
            }
            else if (dias >= 3)
            {
                desconto = 0.05;
            }

            double valorFinal = subtotal * (1 - desconto);

            string descontoString = (desconto * 100).ToString() + "%";

            return Ok(new LocacaoResponse(
                    carro.Modelo,
                    carro.Marca,
                    request.DataInicio.ToString(),
                    request.DataFim.ToString(),
                    carro.ValorDiaria,
                    subtotal,
                    descontoString,
                    valorFinal
                ));
        }
    }
}
