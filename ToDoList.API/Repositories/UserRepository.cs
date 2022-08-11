using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.API.Data;
using ToDoList.API.Entities;
using ToDoList.Models.DTO;

namespace ToDoList.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoListDbContext _context;

        public UserRepository(TodoListDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
