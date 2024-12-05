using ApiPedidin.Models;

namespace ApiPedidin.Repositories.Interfaces
{
    public interface IOrders_ProductsRepository
    {
        Task<List<Orders_ProductsModel>> GetAll();
        Task<Orders_ProductsModel> GetById(long id);
        Task<List<Orders_ProductsModel>> GetByIdOrder(long id);
        Task<List<Orders_ProductsModel>> GetByIdProduct(long id);
        Task<Orders_ProductsModel> Create(Orders_ProductsModel orderProducts);
        Task<Orders_ProductsModel> Update(Orders_ProductsModel orderProducts, long id);
        Task<bool> Delete(long id);
    }
}