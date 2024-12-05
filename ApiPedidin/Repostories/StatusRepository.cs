using ApiPedidin.Data;
using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidin.Repositories
{
    public class StatusRepository : IStatusRepository
    {

        private readonly PedidinDBContext _dbContext;

        public StatusRepository(PedidinDBContext pedidinDBContext)
        {
            _dbContext = pedidinDBContext;
        }

        public async Task<List<StatusModel>> GetAll()
        {
            return await _dbContext.Status.ToListAsync();
        }

        public async Task<StatusModel> GetById(long id)
        {
            var status = await _dbContext.Status.FirstOrDefaultAsync(x => x.Id == id);
            if (status == null)
            {
                throw new Exception($"O Status com ID: {id} não foi encontrado no banco de dados!");
            }
            return status;
        }

        public async Task<StatusModel> Create(StatusModel status)
        {
            await _dbContext.Status.AddAsync(status);
            await _dbContext.SaveChangesAsync();

            return status;
        }

        public async Task<StatusModel> Update(StatusModel status, long id)
        {
            StatusModel statusById = await GetById(id);

            if (statusById == null)
            {
                throw new Exception($"O Status com ID: {id} não foi encontrado no banco de dados!");
            }

            statusById.Name = status.Name;

            _dbContext.Status.Update(statusById);
            await _dbContext.SaveChangesAsync();

            return statusById;
        }

        public async Task<bool> Delete(long id)
        {
            StatusModel statusById = await GetById(id);

            if (statusById == null)
            {
                throw new Exception($"O Status ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Status.Remove(statusById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}