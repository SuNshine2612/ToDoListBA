using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.API.Entities;
using ToDoList.Models.Form;

namespace ToDoList.API.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetTodos(TodoListSearch search);
        Task <Todo> GetById(Guid id);
        Task<Todo> Create(Todo todo);
        Task<Todo> Update(Todo todo);
        Task<Todo> Delete(Todo todo);
    }
}
 