using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPedidin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _requestRepository;
        public OrdersController(IOrdersRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrdersModel>>> GetAllOrderss()
        {
            List<OrdersModel> requests = await _requestRepository.GetAll();
            return Ok(requests);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdersModel>> GetOrdersById(long id)
        {
            OrdersModel request = await _requestRepository.GetById(id);
            return Ok(request);
        }

        /*[HttpGet("status/{idStatus}")]
        public async Task<ActionResult<List<OrdersModel>>> GetOrdersByIdCustomer(long idStatus)
        {
            List<OrdersModel> requests = await _requestRepository.GetByIdCustomer(idStatus);
            return Ok(requests);
        }*/

        [HttpPost]
        public async Task<ActionResult<OrdersModel>> CreateOrders([FromBody] OrdersModel request)
        {
            OrdersModel newOrders = await _requestRepository.Create(request);
            return Ok(newOrders);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrdersModel>> UpdateOrders(long id, [FromBody] OrdersModel request)
        {
            request.Id = id;
            OrdersModel updatedOrders = await _requestRepository.Update(request, id);
            return Ok(updatedOrders);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrders(long id)
        {
            bool deleted = await _requestRepository.Delete(id);
            return Ok(deleted);
        }
    }
}