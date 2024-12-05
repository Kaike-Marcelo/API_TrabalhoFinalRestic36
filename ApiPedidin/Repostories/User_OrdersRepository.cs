using ApiPedidin.Data;
using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidin.Repositories
{
    public class Users_OrdersRepository : IUsers_OrdersRepository
    {

        private readonly PedidinDBContext _dbContext;

        public Users_OrdersRepository(PedidinDBContext pedidinDBContext)
        {
            _dbContext = pedidinDBContext;
        }

        public async Task<List<Users_OrdersModel>> GetAll()
        {
            return await _dbContext.Users_Orders.ToListAsync();
        }

        public async Task<Users_OrdersModel> GetById(long id)
        {
            var user_Orders = await _dbContext.Users_Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (user_Orders == null)
            {
                throw new Exception($"Os Pedidos do usuário, ID: {id} não foi encontrado no banco de dados!");
            }
            return user_Orders;
        }

        public async Task<List<Users_OrdersModel>> GetByIdUser(long id)
        {
            var user_Orders = await _dbContext.Users_Orders.Where(x => x.UserId == id).ToListAsync();
            if (user_Orders == null || user_Orders.Count == 0)
            {
                throw new Exception($"Os Pedidos do usuário, ID: {id} não foi encontrado no banco de dados!");
            }
            return user_Orders;
        }

        public async Task<List<Users_OrdersModel>> GetByIdOrder(long id)
        {
            var user_Orders = await _dbContext.Users_Orders.Where(x => x.OrderId == id).ToListAsync();
            if (user_Orders == null || user_Orders.Count == 0)
            {
                throw new Exception($"Os Pedidos do usuário, ID: {id} não foi encontrado no banco de dados!");
            }
            return user_Orders;
        }

        public async Task<Users_OrdersModel> Create(Users_OrdersModel user_Orders)
        {
            await _dbContext.Users_Orders.AddAsync(user_Orders);
            await _dbContext.SaveChangesAsync();

            return user_Orders;
        }

        public async Task<Users_OrdersModel> Update(Users_OrdersModel user_Orders, long id)
        {
            Users_OrdersModel user_OrdersById = await GetById(id);

            if (user_OrdersById == null)
            {
                throw new Exception($"Os Pedidos do usuário, ID: {id} não foi encontrado no banco de dados!");
            }

            user_OrdersById.OrderId = user_Orders.OrderId;
            user_OrdersById.UserId = user_Orders.UserId;

            _dbContext.Users_Orders.Update(user_OrdersById);
            await _dbContext.SaveChangesAsync();

            return user_OrdersById;
        }

        public async Task<bool> Delete(long id)
        {
            Users_OrdersModel user_OrdersById = await GetById(id);

            if (user_OrdersById == null)
            {
                throw new Exception($"Os Pedidos do usuário, ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Users_Orders.Remove(user_OrdersById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}