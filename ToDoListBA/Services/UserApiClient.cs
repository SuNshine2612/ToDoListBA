using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ToDoList.Models.DTO;

namespace ToDoListBA.Services
{
    public class UserApiClient : IUserApiClient
    {
        private readonly HttpClient _client;

        public UserApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<AssigneeDTO>> GetAssignees()
        {
            var list = await _client.GetFromJsonAsync<List<AssigneeDTO>>("users");
            return list;
        }
    }
}
