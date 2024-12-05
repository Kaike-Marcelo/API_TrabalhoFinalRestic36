using ApiPedidin.Data;
using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiPedidin.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {

        private readonly PedidinDBContext _dbContext;
        private readonly StatusRepository statusRepository;

        public OrdersRepository(PedidinDBContext pedidinDBContext)
        {
            _dbContext = pedidinDBContext;
        }

        public async Task<List<OrdersModel>> GetAll()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<OrdersModel> GetById(long id)
        {
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
            {
                throw new Exception($"O pedido com o ID: {id} não foi encontrado no banco de dados!");
            }
            return order;
        }

        public async Task<OrdersModel> Create(OrdersModel order)
        {
            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();

            return order;
        }

        public async Task<OrdersModel> Update(OrdersModel order, long id)
        {
            OrdersModel orderById = await GetById(id);

            if (orderById == null)
            {
                throw new Exception($"O pedido com ID: {id} não foi encontrado no banco de dados!");
            }

            orderById.value = order.value;

            _dbContext.Orders.Update(orderById);
            await _dbContext.SaveChangesAsync();

            return orderById;
        }

        public async Task<StatusModel> UpdateStatus(long idStatus, StatusModel statusModel)
        {
            StatusModel status = await statusRepository.Update(statusModel, idStatus);
            return status;
        }

        public async Task<bool> Delete(long id)
        {
            OrdersModel orderById = await GetById(id);

            if (orderById == null)
            {
                throw new Exception($"O Status com ID: {id} não foi encontrado no banco de dados!");
            }

            _dbContext.Orders.Remove(orderById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}