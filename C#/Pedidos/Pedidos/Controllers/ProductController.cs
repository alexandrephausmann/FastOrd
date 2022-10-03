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
using Pedidos.Domain.EntidadesEF;

namespace Pedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IGetProductsUseCase _getProductsUseCase;
        private readonly ICreateProductUseCase _createProductUseCase;
        private readonly IUpdateProductUseCase _updateProductUseCase;
        private readonly IDeleteProductUseCase _deleteProductUseCase;
        private readonly IMapper _mapper;

        public ProductController
        (
            ILogger<ProductController> logger, 
            IGetProductsUseCase getProductsUseCase,
            ICreateProductUseCase createProductUseCase,
            IUpdateProductUseCase updateProductUseCase,
            IDeleteProductUseCase deleteProductUseCase,
            IMapper mapper           
        )
        {
            _logger = logger;
            _getProductsUseCase = getProductsUseCase;
            _createProductUseCase = createProductUseCase;
            _updateProductUseCase = updateProductUseCase;
            _deleteProductUseCase = deleteProductUseCase;
            _mapper = mapper;
        }

        [Route("")]
        [HttpPost]
        public IActionResult Create([FromBody] ProductRequest productRequest)
        {
              var productIn = _mapper.Map<TbProduct>(productRequest);
              try
              {
                _createProductUseCase.CreateProduct(productIn);
                return Ok();
              }
              catch (Exception ex)
              {
                  _logger.LogError("Error to create product {0}", ex.Message);
                  return BadRequest($"Error to create product: {ex.Message}");
              }
        }

        [Route("")]
        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _getProductsUseCase.GetProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to get products: {0}", ex.Message);
                return BadRequest($"Error to get products: {ex.Message}");
            }           
        }

        [Route("{id:int}")]
        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = _getProductsUseCase.GetProductById(id);

                if (product == null) return NotFound();

                return Ok(product);
                
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to get products: {0}", ex.Message);
                return BadRequest($"Error to get products: {ex.Message}");
            }
        }

        [Route("")]
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductRequest productRequest)
        {
            var productIn = _mapper.Map<TbProduct>(productRequest);
            try
            {
                _updateProductUseCase.UpdateProduct(productIn);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to update product {0}", ex.Message);
                return BadRequest($"Error to update product: {ex.Message}");
            }
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                _deleteProductUseCase.DeleteProduct(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Error to delete product: {0}", ex.Message);
                return BadRequest($"Error to delete product: {ex.Message}");
            }
        }
    }
}
