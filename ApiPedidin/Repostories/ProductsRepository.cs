using ApiPedidin.Data;
using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidin.Repositories
{
    public class ProductsRepository : IProductsRepository
    {

        private readonly PedidinDBContext _dbContext;

        public ProductsRepository(PedidinDBContext pedidinDBContext)
        {
            _dbContext = pedidinDBContext;
        }

        public async Task<List<ProductsModel>> GetAll()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<ProductsModel> GetById(long id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                throw new Exception($"O produto para o ID: {id} não foi encontrado no banco de dados!");
            }
            return product;
        }

        public async Task<List<ProductsModel>> GetByIdCategories(long id)
        {
            var products = await _dbContext.Products
                                           .Where(x => x.Id == id)
                                           .ToListAsync();

            if (products == null || !products.Any())
            {
                throw new Exception($"Nenhum item do pedido foi encontrado para o ID do cliente: {id}.");
            }

            return products;
        }

        public async Task<ProductsModel> Create(ProductsModel product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }
        

        public async Task<ProductsModel> Update(ProductsModel product, long id)
        {
            ProductsModel productById = await GetById(id);

            if (productById == null)
            {
                throw new Exception($"O produto para o ID: {id} não foi encontrado no banco de dados!");
            }

            productById.Name = product.Name;
            productById.PathImage = product.PathImage;
            productById.Price = product.Price;
            productById.BaseDescription = product.BaseDescription;
            productById.FullDescription = product.FullDescription;
            productById.CategoryId = product.CategoryId;

            _dbContext.Products.Update(productById);
            await _dbContext.SaveChangesAsync();

            return productById;
        }

        public async Task<bool> Delete(long id)
        {
            ProductsModel productById = await GetById(id);

            if (productById == null)
            {
                throw new Exception($"O produto para o ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Products.Remove(productById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}