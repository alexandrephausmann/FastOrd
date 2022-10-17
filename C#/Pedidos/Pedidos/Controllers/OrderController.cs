using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedidos.UseCase.Orders.Interfaces;
using Pedidos.Models.Request;
using Pedidos.Models.In;
using System;
using AutoMapper;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Retorno;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly ICriarPedidoUseCase _criarPedidoUseCase;
        private readonly IConsultarPedidosUseCase _consultarPedidosUseCase;
        private readonly IEnviarMensagemRabbitUseCase _enviarMensagemRabbitUseCase;
        private readonly IMapper _mapper;

        public OrderController
        (
            ILogger<OrderController> logger, 
            ICriarPedidoUseCase enviarPedidoUseCase,
            IConsultarPedidosUseCase consultarPedidosUseCase,
            IEnviarMensagemRabbitUseCase enviarMensagemRabbitUseCase,
            IMapper mapper           
        )
        {
            _logger = logger;
            _criarPedidoUseCase = enviarPedidoUseCase;
            _consultarPedidosUseCase = consultarPedidosUseCase;
            _enviarMensagemRabbitUseCase = enviarMensagemRabbitUseCase;
            _mapper = mapper;
        }

        [Route("")]
        [HttpPost]
        public IActionResult GerarPedido([FromBody]PedidoRequest pedidoRequest)
        {
            var pedidoIn = _mapper.Map<PedidoIn>(pedidoRequest);
            try
            {
                _criarPedidoUseCase.CriarPedido(pedidoIn.OrderDetails, pedidoIn.ProductItens);
                _enviarMensagemRabbitUseCase.EnviarMensagem(pedidoIn);
                return Ok(new { pedido = pedidoIn.OrderDetails, itemPedido = pedidoIn.ProductItens });
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao inserir pedido {0}", ex.Message);
                return BadRequest($"Erro ao inserir pedido: {ex.Message}");
            }
                      
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                PedidosRetorno pedidosRetorno = _consultarPedidosUseCase.GetOrders();
                return Ok(new { pedidosRetorno });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to get Orders: {0}", ex.Message);
                return BadRequest($"Error to get Orders: {ex.Message}");
            }
        }

        [Route("{codStatusPedido:int}")]
        [HttpGet]
        public IActionResult ConsultarPedidos(CodStatusPedido codStatusPedido)
        {
            try
            {
                PedidosRetorno pedidosRetorno = _consultarPedidosUseCase.ConsultarPedidos(codStatusPedido);
                return Ok(new { pedidosRetorno });
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao consultar pedidos: {0}", ex.Message);
                return BadRequest($"Erro ao consultar pedidos: {ex.Message}");
            }           
        }

        
    }
}
