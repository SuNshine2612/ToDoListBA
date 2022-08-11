using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models.DTO;
using ToDoList.Models.Form;
using ToDoListBA.Services;

namespace ToDoListBA.Pages
{
    public partial class TodoList
    {
        [Inject] private ITodoApiClient TodoApiClient { get; set; }
        [Inject] private IUserApiClient UserApiClient { get; set; }

        [Inject] IToastService ToastService { get; set; }

        /// <summary>
        /// list todos
        /// </summary>
        private List<TodoDTO> Todos;

        /// <summary>
        /// form search todo list
        /// </summary>
        private readonly TodoListSearch SearchForm = new();

        /// <summary>
        /// support search form: list assignees
        /// </summary>
        private List<AssigneeDTO> Assignees;


        protected override async Task OnInitializedAsync()
        {
            Todos = await TodoApiClient.GetAll(SearchForm);
            // danh sách user trong form
            Assignees = await UserApiClient.GetAssignees();
        }


        // https://stackoverflow.com/questions/56436577/blazor-form-submit-needs-two-clicks-to-refresh-view
        /*private async void FormSubmited (EditContext editContext)
        {
            Todos = await TodoApiClient.GetAll(SearchForm);
            StateHasChanged();
        }*/

        private async Task FormSubmited(EditContext editContext)
        {
            ToastService.ShowInfo("Search completed", "Info");
            Todos = await TodoApiClient.GetAll(SearchForm);
        }
    }
}
