using ApiPedidin.Data;
using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidin.Repositories
{
    public class UsersRepository : IUsersRepository
    {

        private readonly PedidinDBContext _dbContext;

        public UsersRepository(PedidinDBContext pedidinDBContext)
        {
            _dbContext = pedidinDBContext;
        }

        public async Task<List<UsersModel>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UsersModel> GetById(long id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception($"O cliente para o ID: {id} não foi encontrado no banco de dados!");
            }
            return user;
        }

        public async Task<UsersModel> Create(UsersModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UsersModel> Update(UsersModel user, long id)
        {
            UsersModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"O cliente para o ID: {id} não foi encontrado no banco de dados!");
            }

            userById.Name = user.Name;
            userById.Email = user.Email;
            userById.Password = user.Password;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> Delete(long id)
        {
            UsersModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"O cliente para o ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}