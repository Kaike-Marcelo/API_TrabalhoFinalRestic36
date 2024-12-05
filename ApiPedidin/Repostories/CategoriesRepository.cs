using ApiPedidin.Data;
using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidin.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {

        private readonly PedidinDBContext _dbContext;

        public CategoriesRepository(PedidinDBContext pedidinDBContext)
        {
            _dbContext = pedidinDBContext;
        }

        public async Task<List<CategoriesModel>> GetAll()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<CategoriesModel> GetById(long id)
        {
            var categories = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (categories == null)
            {
                throw new Exception($"A categoria com ID: {id} não foi encontrado no banco de dados!");
            }
            return categories;
        }


        public async Task<CategoriesModel> Create(CategoriesModel categories)
        {
            await _dbContext.Categories.AddAsync(categories);
            await _dbContext.SaveChangesAsync();

            return categories;
        }

        public async Task<CategoriesModel> Update(CategoriesModel categories, long id)
        {
            CategoriesModel categoriesById = await GetById(id);

            if (categoriesById == null)
            {
                throw new Exception($"A categoria com ID: {id} não foi encontrado no banco de dados!");
            }

            categoriesById.Name = categories.Name;
            categoriesById.Description = categories.Description;
            categoriesById.PathImage = categories.PathImage;

            _dbContext.Categories.Update(categoriesById);
            await _dbContext.SaveChangesAsync();

            return categoriesById;
        }

        public async Task<bool> Delete(long id)
        {
            CategoriesModel categoriesById = await GetById(id);

            if (categoriesById == null)
            {
                throw new Exception($"A categoria com ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Categories.Remove(categoriesById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}