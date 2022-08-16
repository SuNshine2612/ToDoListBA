using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ToDoList.Models.DTO;
using ToDoList.Models.Form;
using ToDoList.Models.SeedWorks;

namespace ToDoListBA.Services
{
    public class TodoApiClient : ITodoApiClient
    {
        private readonly HttpClient _client;

        public TodoApiClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<PagedList<TodoDTO>> GetAll(TodoListSearch search)
        {
            //string url = $"todos?name={search.Name}&assigneeId={search.AssigneeId}&priority={search.Priority}";
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = search.PageNumber.ToString(),
            };

            if (!string.IsNullOrEmpty(search.Name))
                queryStringParam.Add("name", search.Name);
            if (search.AssigneeId.HasValue)
                queryStringParam.Add("assigneeId", search.AssigneeId.ToString());
            if (search.Priority.HasValue)
                queryStringParam.Add("priority", search.Priority.ToString());

            string url = QueryHelpers.AddQueryString("todos", queryStringParam);

            var list = await _client.GetFromJsonAsync<PagedList<TodoDTO>>(url);
            return list;
        }

        public async Task<TodoDTO> GetById(string id)
        {
            var detail = await _client.GetFromJsonAsync<TodoDTO>($"todos/{id}");
            return detail;
        }

        public async Task<bool> InsertTask(TodoCreate todo)
        {
            var rs = await _client.PostAsJsonAsync("todos", todo);
            return rs.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateTask(Guid id, TodoUpdate todo)
        {
            var rs = await _client.PutAsJsonAsync($"todos/{id}", todo);
            return rs.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTask(Guid id)
        {
            var rs = await _client.DeleteAsync($"todos/{id}");
            return rs.IsSuccessStatusCode;
        }

        public async Task<bool> AssignTask(TodoAssignUser assignUser)
        {
            var rs = await _client.PostAsJsonAsync("todos/AssignUser", assignUser);

            return rs.IsSuccessStatusCode;
        }
    }
}
