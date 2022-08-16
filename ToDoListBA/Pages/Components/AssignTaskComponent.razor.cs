using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models.DTO;
using ToDoList.Models.Form;
using ToDoListBA.Services;

namespace ToDoListBA.Pages.Components
{
    public partial class AssignTaskComponent
    {
        // Inject
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private ITodoApiClient TodoApiClient { get; set; }
        [Inject] private IUserApiClient UserApiClient { get; set; }

        protected bool ShowDialog { get; set; }

        private TodoAssignUser AssignUserForm { get; set; } = new TodoAssignUser();

        private List<AssigneeDTO> Assignees;

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Assignees = await UserApiClient.GetAssignees();
        }

        // Không phải gán trong Initialize mà gán trong lúc set param
        protected override async Task OnParametersSetAsync()
        {
            if(AssignUserForm.TodoId != Guid.Empty)
            {
                var task = await TodoApiClient.GetById(AssignUserForm.TodoId.ToString());
                AssignUserForm.UserId = task.AssigneeId;
            }
        }

        public void Show(Guid id)
        {
            ShowDialog = true;
            AssignUserForm.TodoId = id;
            StateHasChanged();
        }

        private void Hide()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        protected async Task HandleAssignSubmit()
        {
            // Lưu lại userid vào trong task todo!
            var result = await TodoApiClient.AssignTask(AssignUserForm);
            if (result)
            {
                ShowDialog = false;
                await CloseEventCallback.InvokeAsync(result);
            }
            else
            {
                ToastService.ShowError("Assign task failed!!");
            }
        }
    }
}
