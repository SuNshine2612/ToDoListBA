using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models.DTO;

namespace ToDoListBA.Services
{
    public interface IUserApiClient
    {
        Task<List<AssigneeDTO>> GetAssignees();
    }
}
