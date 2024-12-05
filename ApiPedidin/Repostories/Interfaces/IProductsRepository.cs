using ApiPedidin.Models;

namespace ApiPedidin.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<ProductsModel>> GetAll();
        Task<ProductsModel> GetById(long id);
        Task<List<ProductsModel>> GetByIdCategories(long id);
        Task<ProductsModel> Create(ProductsModel request);
        Task<ProductsModel> Update(ProductsModel request, long id);
        Task<bool> Delete(long id);
    }
}