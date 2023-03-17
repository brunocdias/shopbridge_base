using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shopbridge_base.Application.Commands.DeleteProduct;
using Shopbridge_base.Application.Commands.PostProduct;
using Shopbridge_base.Application.Commands.PutProduct;
using Shopbridge_base.Application.Queries.GetProduct;
using Shopbridge_base.Application.Queries.GetProductById;
using Shopbridge_base.Domain.Models;
using Shopbridge_base.Domain.Services.Interfaces;
using Shopbridge_base.Infrastructure.Extensions;
using Shopbridge_base.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopbridge_base.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> logger;
        private readonly IMediator _mediator;
        private readonly IValidator<ProductModel> _validator;
        public ProductsController(IProductService productService,
            IMediator mediator,
            IValidator<ProductModel> validator)
        {
            _productService = productService;
            _mediator = mediator;
            _validator = validator;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            var result = await _mediator.Send(new GetProductQueryRequest { });

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var result = await _mediator.Send(new GetProductByIdQueryRequest { Id = id });

            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] PutProductCommand product)
        {
            var validation = await _validator.ValidateAsync(product);

            if (!validation.IsValid)
            {
                return BadRequest(validation.GetErrors());
            }

            product.Product_Id = id;

            var result = await _mediator.Send(product);

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(PostProductCommand product)
        {
            var validation = await _validator.ValidateAsync(product);

            if (!validation.IsValid)
            {
                return BadRequest(validation.GetErrors());
            }

            var command = await _mediator.Send(product);

            return Ok(command);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommand { Product_Id = id });

            return Ok(result);
        }
        
    }
}
