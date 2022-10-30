using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedidos.UseCase.Orders.Interfaces;
using Pedidos.Models.Request;
using Pedidos.Models.In;
using System;
using AutoMapper;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Response;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly ICriarPedidoUseCase _criarPedidoUseCase;
        private readonly IConsultarPedidosUseCase _consultarPedidosUseCase;
        private readonly IChangeOrderStatusUseCase _changeOrderStatusUseCase;
        private readonly IEnviarMensagemRabbitUseCase _enviarMensagemRabbitUseCase;
        private readonly IMapper _mapper;

        public OrderController
        (
            ILogger<OrderController> logger, 
            ICriarPedidoUseCase enviarPedidoUseCase,
            IConsultarPedidosUseCase consultarPedidosUseCase,
            IChangeOrderStatusUseCase changeOrderStatusUseCase,
            IEnviarMensagemRabbitUseCase enviarMensagemRabbitUseCase,
            IMapper mapper           
        )
        {
            _logger = logger;
            _criarPedidoUseCase = enviarPedidoUseCase;
            _consultarPedidosUseCase = consultarPedidosUseCase;
            _changeOrderStatusUseCase = changeOrderStatusUseCase;
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
                OrdersResponse ordersResponse = _consultarPedidosUseCase.GetOrders();
                return Ok(new { ordersResponse });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to get Orders: {0}", ex.Message);
                return BadRequest($"Error to get Orders: {ex.Message}");
            }
        }

        [Route("{codStatusPedido:int}")]
        [HttpGet]
        public IActionResult ConsultarPedidos(IdOrderStatus codStatusPedido)
        {
            try
            {
                OrdersResponse pedidosRetorno = _consultarPedidosUseCase.ConsultarPedidos(codStatusPedido);
                return Ok(new { pedidosRetorno });
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao consultar pedidos: {0}", ex.Message);
                return BadRequest($"Erro ao consultar pedidos: {ex.Message}");
            }           
        }

        [Route("updateStatus")]
        [HttpPut]
        public IActionResult UpdateStatus([FromBody] ChangeStatusRequest changeStatusRequest)
        {
            var changeStatusIn = _mapper.Map<ChangeStatusIn>(changeStatusRequest);
            try
            {
                var orderStatus = _changeOrderStatusUseCase.ChangeOrderStatus(changeStatusIn.IdOrder, changeStatusIn.IdOrderStatus);
                _enviarMensagemRabbitUseCase.EnviarMensagem(changeStatusIn);
                return Ok(orderStatus);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to update the order status {0}", ex.Message);
                return BadRequest($"Error to update the order status: {ex.Message}");
            }

        }


    }
}
