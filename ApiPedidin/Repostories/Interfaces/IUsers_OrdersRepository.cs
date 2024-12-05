using ApiPedidin.Models;

namespace ApiPedidin.Repositories.Interfaces
{
    public interface IUsers_OrdersRepository
    {
        Task<List<Users_OrdersModel>> GetAll();
        Task<Users_OrdersModel> GetById(long id);
        Task<List<Users_OrdersModel>> GetByIdUser(long id);
        Task<List<Users_OrdersModel>> GetByIdOrder(long id);
        Task<Users_OrdersModel> Create(Users_OrdersModel itemRequest);
        Task<Users_OrdersModel> Update(Users_OrdersModel itemRequest, long id);
        Task<bool> Delete(long id);
    }
}