using ApiPedidin.Models;

namespace ApiPedidin.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        Task<List<StatusModel>> GetAll();
        Task<StatusModel> GetById(long id);
        Task<StatusModel> Create(StatusModel customer);
        Task<StatusModel> Update(StatusModel customer, long id);
        Task<bool> Delete(long id);
    }
}