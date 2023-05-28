using Catalog.API.Entities;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CatalogController> _catalogControllerLogger;
        public CatalogController(IProductRepository productRepository, ILogger<CatalogController> catalogControllerLogger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _catalogControllerLogger = catalogControllerLogger ?? throw new ArgumentNullException(nameof(catalogControllerLogger));

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            IEnumerable<Product> products = await _productRepository.GetProducts();

            if (products is null)
            {
                _catalogControllerLogger.LogError($"Products not found");
                return NotFound();
            }

            return Ok(products);
        }

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> GetProductById(string id)
        {
            Product product = await _productRepository.GetProductById(id);

            if (product is null)
            {
                _catalogControllerLogger.LogError($"Product with id: {id}, not found");
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet]
        [Route("[action]/{category}", Name = "GetProductByCategory")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> GetProductByCategory(string category)
        {
            IEnumerable<Product> products = await _productRepository.GetProductCategory(category);

            if (products is null)
            {
                _catalogControllerLogger.LogError($"Product with category: {category}, not found");
                return NotFound();
            }

            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Product))]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            await _productRepository.CreateProduct(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id}, product);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(bool))]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            bool updateResult = await _productRepository.UpdateProduct(product);

            return Ok(updateResult);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            bool deleteResult = await _productRepository.DeleteProduct(id);

            return Ok(deleteResult);
        }
    }
}
