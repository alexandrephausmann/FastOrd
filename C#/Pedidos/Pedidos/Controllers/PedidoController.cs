using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedidos.UseCase.Interfaces;
using Pedidos.Models.Request;
using Pedidos.Models.In;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IEnviarPedidoUseCase _enviarPedidoUseCase;

        public PedidoController(ILogger<PedidoController> logger, IEnviarPedidoUseCase enviarPedidoUseCase)
        {
            _logger = logger;
            _enviarPedidoUseCase = enviarPedidoUseCase;
        }

        [Route("api/GerarPedido")]
        [HttpPost]
        public IActionResult GerarPedido([FromBody]PedidoRequest pedidoRequest)
        {
            var pedidoIn = new PedidoIn()
            {
                Pedido = pedidoRequest.Pedido,
                ItensPedido = pedidoRequest.ItensPedido
            };
            var codigoPedido = _enviarPedidoUseCase.CriarPedido(pedidoIn.Pedido, pedidoIn.ItensPedido);

            _enviarPedidoUseCase.SendMessage(pedidoIn);

            return Ok(new { pedido = codigoPedido });
        }
    }
}
