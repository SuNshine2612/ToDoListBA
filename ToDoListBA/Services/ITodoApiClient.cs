using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models.DTO;
using ToDoList.Models.Form;

namespace ToDoListBA.Services
{
    public interface ITodoApiClient
    {
        /// <summary>
        /// get all datas
        /// </summary>
        /// <returns></returns>
        Task<List<TodoDTO>> GetAll(TodoListSearch search);

        /// <summary>
        /// get detail data by id
        /// </summary>
        /// <param name="id">Todo Id</param>
        /// <returns></returns>
        Task<TodoDTO> GetById(string id);

        Task<bool> Insert(TodoCreate todo);
    }
}
