using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ToDoList.Models.DTO;
using ToDoList.Models.Form;

namespace ToDoListBA.Services
{
    public class TodoApiClient : ITodoApiClient
    {
        private readonly HttpClient _client;

        public TodoApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<TodoDTO>> GetAll(TodoListSearch search)
        {
            string url = $"todos?name={search.Name}&assigneeId={search.AssigneeId}&priority={search.Priority}";
            var list = await _client.GetFromJsonAsync<List<TodoDTO>>(url);
            return list;
        }

        public async Task<TodoDTO> GetById(string id)
        {
            var detail = await _client.GetFromJsonAsync<TodoDTO>($"todos/{id}");
            return detail;
        }

        public async Task<bool> Insert(TodoCreate todo)
        {
            var rs = await _client.PostAsJsonAsync("todos", todo);
            return rs.IsSuccessStatusCode;
        }

        public async Task<bool> Update(Guid id, TodoUpdate todo)
        {
            var rs = await _client.PutAsJsonAsync($"todos/{id}", todo);
            return rs.IsSuccessStatusCode;
        }
    }
}
