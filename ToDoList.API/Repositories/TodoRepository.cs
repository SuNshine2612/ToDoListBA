using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.API.Data;
using ToDoList.API.Entities;
using ToDoList.Models.DTO;
using ToDoList.Models.Form;
using ToDoList.Models.SeedWorks;

namespace ToDoList.API.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoListDbContext _context;
        public TodoRepository(TodoListDbContext context)
        {
            _context = context;
        }

        public async Task<Todo> Create(Todo todo)
        {
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo> Delete(Todo todo)
        {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo> GetById(Guid id)
        {
            return await _context.Todos.FindAsync(id);
        }

        public async Task<PagedList<Todo>> GetTodos(TodoListSearch search)
        {
            /* return await _context.Todos
             .Include(x => x.Assignee)
             .ToListAsync();*/


            var query = _context.Todos
                .Include(x => x.Assignee)
                .AsQueryable(); // convert here to use where contain below
            if(!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }

            if (search.AssigneeId.HasValue)
            {
                query = query.Where(x => x.AssigneeId == search.AssigneeId.Value);
            }

            if (search.Priority.HasValue)
            {
                query = query.Where(x => x.Priority == search.Priority.Value);
            }

            var count = await query.CountAsync();
            var datas = await query.OrderByDescending(x => x.CreatedDate)
                .Skip((search.PageNumber - 1) * search.PageSize)
                .Take(search.PageSize)
                .ToListAsync();

            return new PagedList<Todo>(datas, count, search.PageNumber, search.PageSize);
        }

        public async Task<Todo> Update(Todo todo)
        {
            _context.Todos.Update(todo);
            await _context.SaveChangesAsync();
            return todo;
        }
    }
}
