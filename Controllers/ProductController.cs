using APIDevelopmentUsingDapper.Interfaces;
using APIDevelopmentUsingDapper.Model;
using APIDevelopmentUsingDapper.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDevelopmentUsingDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var Products = await _repository.GetAllProductsAsync();
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var Product = await _repository.GetProductByIdAsync(id);
            if(Product == null)
            {
                return NotFound();
            }
            return Ok(Product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product Product)
        {
            int newProductId = await _repository.CreateProductAsync(Product);
            Product.Id = newProductId;
            return CreatedAtAction(nameof(GetProduct), new { id = newProductId }, Product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product Product)
        {
            if(id != Product.Id)
            {
                return BadRequest();
            }

            bool updated = await _repository.UpdateProductAsync(Product);
            if(!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            bool deleted = await _repository.DeleteProductAsync(id);
            if(!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
