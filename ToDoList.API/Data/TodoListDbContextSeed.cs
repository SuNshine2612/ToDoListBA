using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.API.Entities;
using ToDoList.Models.Enums;

namespace ToDoList.API.Data
{
    public class TodoListDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public async Task SeedAsync(TodoListDbContext context, ILogger<TodoListDbContextSeed> logger)
        {

            if(!context.Todos.Any())
            {
                context.Todos.Add(new Todo()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sample task todo 1",
                    CreatedDate = DateTime.Now,
                    Priority =Priority.High,
                    Status = Status.Open
                }); ;
            }

            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Minh",
                    LastName = "Duong",
                    Email = "anhminh2612@gmail.com",
                    PhoneNumber = "0937093030",
                    UserName = "admin"
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123!");
                context.Users.Add(user);    
            }
            await context.SaveChangesAsync();
        }
    }
}
