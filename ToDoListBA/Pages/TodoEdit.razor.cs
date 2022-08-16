using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Threading.Tasks;
using ToDoList.Models.DTO;
using ToDoList.Models.Form;
using ToDoListBA.Services;

namespace ToDoListBA.Pages
{
    public partial class TodoEdit
    {
        [Inject] private ITodoApiClient TodoApiClient { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        [Inject] IToastService ToastService { get; set; }



        [Parameter]
        public string TodoId { get; set; }
        protected TodoUpdate TodoDetail = new();


        private async Task SubmitForm(EditContext context)
        {
            var rs = await TodoApiClient.UpdateTask(Guid.Parse(TodoId), TodoDetail);
            if (rs is true)
            {
                ToastService.ShowSuccess($"{TodoDetail.Name} has been updated successfully.", "Ok");
                NavigationManager.NavigateTo("todo-list");
            }
            else
            {
                ToastService.ShowError("Can not update task", "Error");
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var detailDTO = await TodoApiClient.GetById(TodoId);
            TodoDetail.Name = detailDTO.Name;
            TodoDetail.Priority = detailDTO.Priority;
        }
    }

}
