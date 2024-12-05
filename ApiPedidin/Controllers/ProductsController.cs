using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPedidin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productRepository;
        public ProductsController(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductsModel>>> GetAllProductss()
        {
            List<ProductsModel> products = await _productRepository.GetAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsModel>> GetProductsById(long id)
        {
            ProductsModel product = await _productRepository.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductsModel>> CreateProducts([FromForm] ProductsModel product, IFormFile file)
        {
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName); //"wwwroot"
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                product.PathImage = $"images/products/{file.FileName}";
            }
            ProductsModel newProducts = await _productRepository.Create(product);
            return Ok(newProducts);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Nenhum Arquivo Enviado.");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName); //"wwwroot"
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var imagePath = $"images/products/{file.FileName}";
            return Ok(new { PathImage = imagePath });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductsModel>> UpdateProducts(long id, [FromBody] ProductsModel product)
        {
            ProductsModel productById = await _productRepository.GetById(id);

            if (productById == null)
            {
                return NotFound($"O produto para o ID: {id} não foi encontrado no banco de dados!");
            }

            productById.Name = product.Name;
            productById.PathImage = product.PathImage; // Atualize o caminho da imagem se necessário
            productById.Price = product.Price;
            productById.BaseDescription = product.BaseDescription;
            productById.FullDescription = product.FullDescription;
            productById.CategoryId = product.CategoryId;

            ProductsModel updatedProducts = await _productRepository.Update(productById, id);
            return Ok(updatedProducts);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducts(long id)
        {
            bool deleted = await _productRepository.Delete(id);
            return Ok(deleted);
        }
    }
}