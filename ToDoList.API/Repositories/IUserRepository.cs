using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.API.Entities;

namespace ToDoList.API.Repositories
{
    public interface IUserRepository
    {

        Task<List<User>> GetUsers();
    }
}
