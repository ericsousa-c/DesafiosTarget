using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendasComissoesAPI.Models;
using VendasComissoesAPI.Services;

namespace VendasComissoesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        public readonly ComissaoService _comissaoService;

        public VendasController(ComissaoService comissaoService)
        {
            _comissaoService = comissaoService;
        }

        [HttpPost]
        public ActionResult Post(VendasRequest request)
        {
            if (request is null || request.Vendas is null || !request.Vendas.Any())
            {
                return BadRequest("Nenhuma venda enviada.");
            }

            var vendas = request.Vendas;

            var vendasVendedor = vendas
                .GroupBy(v => v.Vendedor)
                .Select(d => new
                {
                    Vendedor = d.Key,
                    TotalVendas = d.Sum(v => decimal.Round(v.Valor, 2)),
                    TotalComissao = d.Sum(v => _comissaoService.CalcularComissao(v.Valor))
                }).ToList();


            return Ok(vendasVendedor);
        }
    }
}
