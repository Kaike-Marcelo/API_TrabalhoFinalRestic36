using ApiPedidin.Models;

namespace ApiPedidin.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        Task<List<CategoriesModel>> GetAll();
        Task<CategoriesModel> GetById(long id);
        Task<CategoriesModel> Create(CategoriesModel customer);
        Task<CategoriesModel> Update(CategoriesModel customer, long id);
        Task<bool> Delete(long id);
    }
}