using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models.DTO;
using ToDoList.Models.Form;
using ToDoList.Models.SeedWorks;

namespace ToDoListBA.Services
{
    public interface ITodoApiClient
    {
        /// <summary>
        /// get all datas
        /// </summary>
        /// <returns></returns>
        Task<PagedList<TodoDTO>> GetAll(TodoListSearch search);

        /// <summary>
        /// get detail data by id
        /// </summary>
        /// <param name="id">Todo Id</param>
        /// <returns></returns>
        Task<TodoDTO> GetById(string id);

        Task<bool> InsertTask(TodoCreate todo);

        Task<bool> UpdateTask(Guid id, TodoUpdate todo);

        Task<bool> AssignTask(TodoAssignUser assignUser);

        Task<bool> DeleteTask(Guid id);


    }
}
