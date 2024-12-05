using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPedidin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriesModel>>> GetAllCategoriess()
        {
            List<CategoriesModel> categoriess = await _categoriesRepository.GetAll();
            return Ok(categoriess);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriesModel>> GetCategoriesById(long id)
        {
            CategoriesModel categories = await _categoriesRepository.GetById(id);
            return Ok(categories);
        }

        /*[HttpGet("products/{idProduct}")]
        public async Task<ActionResult<List<CategoriesModel>>> GetCategoriesByIdProduct(long idProduct)
        {
            List<CategoriesModel> categories = await _categoriesRepository.(idProduct);
            return Ok(categories);
        }*/


        [HttpPost]
        public async Task<ActionResult<CategoriesModel>> CreateCategories([FromBody] CategoriesModel categories)
        {
            CategoriesModel newCategories = await _categoriesRepository.Create(categories);
            return Ok(newCategories);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoriesModel>> UpdateCategories(long id, [FromBody] CategoriesModel categories)
        {
            categories.Id = id;
            CategoriesModel updatedCategories = await _categoriesRepository.Update(categories, id);
            return Ok(updatedCategories);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategories(long id)
        {
            bool deleted = await _categoriesRepository.Delete(id);
            return Ok(deleted);
        }
    }
}