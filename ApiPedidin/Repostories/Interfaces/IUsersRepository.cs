using ApiPedidin.Models;

namespace ApiPedidin.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<UsersModel>> GetAll();
        Task<UsersModel> GetById(long id);
        Task<UsersModel> Create(UsersModel customer);
        Task<UsersModel> Update(UsersModel customer, long id);
        Task<bool> Delete(long id);
    }
}