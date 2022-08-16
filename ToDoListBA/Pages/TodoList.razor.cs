using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models.DTO;
using ToDoList.Models.Form;
using ToDoList.Models.SeedWorks;
using ToDoListBA.Components;
using ToDoListBA.Pages.Components;
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
        private MetaData MetaData { get; set; } = new MetaData();

        /// <summary>
        /// form search todo list
        /// </summary>
        private TodoListSearch SearchForm = new();

        protected ConfirmComponent DeleteConfirmation { get; set; }
        protected AssignTaskComponent AssignTask { get; set; }


        private async Task GetTodos()
        {
            var pagingResponse = await TodoApiClient.GetAll(SearchForm);
            Todos = pagingResponse.Datas;
            MetaData = pagingResponse.MetaData;
        }

        private async Task SelectedPage(int page)
        {
            SearchForm.PageNumber = page;
            await GetTodos();
        }

        protected override async Task OnInitializedAsync()
        {
            await GetTodos();

        }

        public async Task SearchTask(TodoListSearch search)
        {
            SearchForm = search;
            await GetTodos();
        }

        // Xử lý khi người dùng bấm button show delete
        public void OpenDeleteTaskPopup(Guid id)
        {
            DeleteId = id;
            DeleteConfirmation.Show();
        }

        public async Task OnConfirmDeleteTask(bool confirm)
        {
            if(confirm)
            {
                await TodoApiClient.DeleteTask(DeleteId);
                await GetTodos();
            }
        }


        public void OpenAssignPopup(Guid id)
        {
            AssignTask.Show(id);
        }

        public async Task OnAssignTaskSuccess(bool result)
        {
            if(result)
            {
                await GetTodos();
            }
        }
    }
}
