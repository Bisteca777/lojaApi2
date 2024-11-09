using LojaApi.Models;
using LojaApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace PedidosApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]


    public class PedidosController : ControllerBase
    {
        private readonly PedidosController _pedidosController;

        public PedidosController(PedidosController pedidosController)
        {
            _pedidosController = pedidosController;
        }

        [HttpGet("listar-Pedidos")]
        public async Task<IActionResult> ListarPedidosDB()
        {
            var pedidos = await _pedidosController.ListarPedidosDB();
            return Ok(pedidos);
        }

        [HttpGet("consultar-status")]
        public async Task<IActionResult> ConsultarStatusPedido(int pedidoId)
        {
            var status = await _PedidosRepository.ConsultarStatusPedidoDB(pedidoId);

            return Ok(new { pedidoId, status });
        }


        private IActionResult Ok(IActionResult pedidos)
        {
            throw new NotImplementedException();
        }
    }

}
