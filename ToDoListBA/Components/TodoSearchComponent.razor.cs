using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models.DTO;
using ToDoList.Models.Form;
using ToDoListBA.Services;

namespace ToDoListBA.Components
{

    public partial class TodoSearchComponent
    {
        [Inject] private IUserApiClient UserApiClient { get; set; }

        // sau khi submit form, sử dụng EventCallback để báo cho lớp cha biết có sụ thay đổi
        [Parameter]
        public EventCallback<TodoListSearch> OnSearch { get; set; }

        /// <summary>
        /// form search todo list
        /// </summary>
        private readonly TodoListSearch SearchForm = new();

        /// <summary>
        /// support search form: list assignees
        /// </summary>
        private List<AssigneeDTO> Assignees;

        


        // https://stackoverflow.com/questions/56436577/blazor-form-submit-needs-two-clicks-to-refresh-view
        /*private async void FormSubmited (EditContext editContext)
        {
            Todos = await TodoApiClient.GetAll(SearchForm);
            StateHasChanged();
        }*/

        private async Task FormSubmited(EditContext editContext)
        {
            await OnSearch.InvokeAsync(SearchForm);
        }

        protected override async Task OnInitializedAsync()
        {
            Assignees = await UserApiClient.GetAssignees();
        }
    }
}
