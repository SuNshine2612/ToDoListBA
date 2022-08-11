using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.API.Repositories;
using ToDoList.Models.DTO;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository repository)
        {
            _userRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetUsers();
            var assignees = users.Select(x => new AssigneeDTO()
            {
                Id = x.Id,
                Fullname = $"{x.FirstName} {x.LastName}"
            });
            return Ok(assignees);

        }
    }
}
