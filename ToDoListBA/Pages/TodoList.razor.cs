using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models.DTO;
using ToDoList.Models.Form;
using ToDoListBA.Components;
using ToDoListBA.Services;

namespace ToDoListBA.Pages
{
    public partial class TodoList
    {
        [Inject] private ITodoApiClient TodoApiClient { get; set; }

        private Guid DeleteId { get; set; }

        /// <summary>
        /// list todos
        /// </summary>
        private List<TodoDTO> Todos;

        /// <summary>
        /// form search todo list
        /// </summary>
        private TodoListSearch SearchForm = new();

        protected ConfirmComponent DeleteConfirmation { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Todos = await TodoApiClient.GetAll(SearchForm);
            // danh sách user trong form

        }

        public async Task SearchTask(TodoListSearch search)
        {
            SearchForm = search;
            Todos = await TodoApiClient.GetAll(SearchForm);
        }

        // Xử lý khi người dùng bấm button show delete
        public  void DeleteTask(Guid id)
        {
            DeleteId = id;
            DeleteConfirmation.Show();
        }

        public async Task OnConfirmDeleteTask(bool confirm)
        {
            if(confirm)
            {
                await TodoApiClient.Delete(DeleteId);
                Todos = await TodoApiClient.GetAll(SearchForm);
            }
        }
    }
}
