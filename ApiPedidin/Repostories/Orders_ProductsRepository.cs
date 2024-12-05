using ApiPedidin.Data;
using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidin.Repositories
{
    public class Orders_ProductsRepository : IOrders_ProductsRepository
    {

        private readonly PedidinDBContext _dbContext;

        public Orders_ProductsRepository(PedidinDBContext pedidinDBContext)
        {
            _dbContext = pedidinDBContext;
        }

        public async Task<List<Orders_ProductsModel>> GetAll()
        {
            return await _dbContext.Orders_Products.ToListAsync();
        }

        public async Task<Orders_ProductsModel> GetById(long id)
        {
            var user = await _dbContext.Orders_Products.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new Exception($"Os Produtos do Pedido com ID: {id} não foi encontrado no banco de dados!");
            }
            return user;
        }

        public async Task<List<Orders_ProductsModel>> GetByIdOrder(long id)
        {
            var user = await _dbContext.Orders_Products.Where(x => x.OrderId == id).ToListAsync();
            if (user == null)
            {
                throw new Exception($"Os Produtos do Pedido com ID: {id} não foi encontrado no banco de dados!");
            }
            return user;
        }

        public async Task<List<Orders_ProductsModel>> GetByIdProduct(long id)
        {
            var user = await _dbContext.Orders_Products.Where(x => x.ProductId == id).ToListAsync();
            if (user == null)
            {
                throw new Exception($"Os Produtos do Pedido com ID: {id} não foi encontrado no banco de dados!");
            }
            return user;
        }

        public async Task<Orders_ProductsModel> Create(Orders_ProductsModel user)
        {
            await _dbContext.Orders_Products.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<Orders_ProductsModel> Update(Orders_ProductsModel user, long id)
        {
            Orders_ProductsModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"O cliente para o ID: {id} não foi encontrado no banco de dados!");
            }

            userById.OrderId = user.OrderId;
            userById.ProductId = user.ProductId;

            _dbContext.Orders_Products.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> Delete(long id)
        {
            Orders_ProductsModel userById = await GetById(id);

            if (userById == null)
            {
                throw new Exception($"Os Produtos do Pedido com ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Orders_Products.Remove(userById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}