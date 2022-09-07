using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pedidos.UseCase.Orders.Interfaces;
using Pedidos.Models.Request;
using Pedidos.Models.In;
using System;
using AutoMapper;
using Pedidos.Domain.Enums;
using Pedidos.Domain.Retorno;
using Pedidos.UseCase.Products.Interfaces;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IGetProductsUseCase _getProductsUseCase;
        private readonly IMapper _mapper;

        public ProductController
        (
            ILogger<ProductController> logger, 
            IGetProductsUseCase getProductsUseCase,
            IMapper mapper           
        )
        {
            _logger = logger;
            _getProductsUseCase = getProductsUseCase;
            _mapper = mapper;
        }

        [Route("api/create")]
        [HttpPost]
        public IActionResult Create([FromBody]PedidoRequest pedidoRequest)
        {
            /*  var pedidoIn = _mapper.Map<PedidoIn>(pedidoRequest);
              try
              {
                  _criarPedidoUseCase.CriarPedido(pedidoIn.Pedido, pedidoIn.ItensPedido);
                  _enviarMensagemRabbitUseCase.EnviarMensagem(pedidoIn);
                  return Ok(new { pedido = pedidoIn.Pedido, itemPedido = pedidoIn.ItensPedido });
              }
              catch (Exception ex)
              {
                  _logger.LogError("Erro ao inserir pedido {0}", ex.Message);
                  return BadRequest($"Erro ao inserir pedido: {ex.Message}");
              }*/
            return Ok();
        }

        [Route("api/getProducts")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _getProductsUseCase.GetProducts();
                return Ok(new { products = products });
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to get products: {0}", ex.Message);
                return BadRequest($"Error to get products: {ex.Message}");
            }           
        }

        [Route("api/updateProduct")]
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] PedidoRequest pedidoRequest)
        {
            try
            {
               // PedidosRetorno pedidosRetorno = _consultarPedidosUseCase.ConsultarPedidos(codStatusPedido);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao consultar pedidos: {0}", ex.Message);
                return BadRequest($"Erro ao consultar pedidos: {ex.Message}");
            }
        }

        [Route("api/deleteProduct")]
        [HttpDelete]
        public IActionResult DeleteProduct([FromBody] string id)
        {
            try
            {
                //PedidosRetorno pedidosRetorno = _consultarPedidosUseCase.ConsultarPedidos(codStatusPedido);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Erro ao consultar pedidos: {0}", ex.Message);
                return BadRequest($"Erro ao consultar pedidos: {ex.Message}");
            }
        }
    }
}
