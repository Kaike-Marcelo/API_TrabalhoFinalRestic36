using ApiPedidin.Models;

namespace ApiPedidin.Repositories.Interfaces
{
    public interface IOrdersRepository
    {
        Task<List<OrdersModel>> GetAll();
        Task<OrdersModel> GetById(long id);
        Task<OrdersModel> Create(OrdersModel product);
        Task<OrdersModel> Update(OrdersModel product, long id);
        Task<StatusModel> UpdateStatus(long idStatus, StatusModel statusModel);
        Task<bool> Delete(long id);
    }
}