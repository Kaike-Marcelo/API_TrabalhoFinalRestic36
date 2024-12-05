using ApiPedidin.Models;
using ApiPedidin.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPedidin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersRepository _userRepository;
        public UserController(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersModel>>> GetAllUsers()
        {
            List<UsersModel> customers = await _userRepository.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsersModel>> GetUserById(long id)
        {
            UsersModel customer = await _userRepository.GetById(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<UsersModel>> CreateUser([FromBody] UsersModel customer)
        {
            UsersModel newUser = await _userRepository.Create(customer);
            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsersModel>> UpdateUser(long id, [FromBody] UsersModel customer)
        {
            customer.Id = id;
            UsersModel updatedUser = await _userRepository.Update(customer, id);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(long id)
        {
            bool deleted = await _userRepository.Delete(id);
            return Ok(deleted);
        }
    }
}