using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedidos.UseCase.Interfaces;
using Pedidos.Models.Request;
using Pedidos.Models.In;
using System;
using AutoMapper;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<PedidoController> _logger;
        private readonly IEnviarPedidoUseCase _enviarPedidoUseCase;
        private readonly IMapper _mapper;

        public PedidoController(ILogger<PedidoController> logger, IEnviarPedidoUseCase enviarPedidoUseCase, IMapper mapper)
        {
            _logger = logger;
            _enviarPedidoUseCase = enviarPedidoUseCase;
            _mapper = mapper;
        }

        [Route("api/GerarPedido")]
        [HttpPost]
        public IActionResult GerarPedido([FromBody]PedidoRequest pedidoRequest)
        {
            var pedidoIn = _mapper.Map<PedidoIn>(pedidoRequest);
            try
            {
                _enviarPedidoUseCase.CriarPedido(pedidoIn.Pedido, pedidoIn.ItensPedido);
                _enviarPedidoUseCase.SendMessage(pedidoIn);
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao inserir pedido {0}", ex.Message);
            }
           
            return Ok(new { pedido = pedidoIn.Pedido.CodPedido });
        }
    }
}
