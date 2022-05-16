using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMQ.Entidades;
using RabbitMQ.Interfaces;
using RabbitMQ.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult GerarPedido(PedidoRequest pedidoRequest)
        {
            var pedido = new Pedido() { 
                CodPedido = pedidoRequest.CodPedido,
                CodIntegracao = pedidoRequest.CodIntegracao
            };

            _enviarPedidoUseCase.SendMessage(pedido);

            return Ok(new { id = pedido.CodIntegracao });
        }
    }
}
