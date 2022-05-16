using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedidos.UseCase.Interfaces;
using Pedidos.Domain.Entidades;
using RabbitMQ.Request;

namespace FastPedidos.Controllers
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
            var pedido = new Pedido()
            {
                CodPedido = pedidoRequest.CodPedido,
                CodIntegracao = pedidoRequest.CodIntegracao
            };

            _enviarPedidoUseCase.SendMessage(pedido);

            return Ok(new { id = pedido.CodIntegracao });
        }
    }
}
