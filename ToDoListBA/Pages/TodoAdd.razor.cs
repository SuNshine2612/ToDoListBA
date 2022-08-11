using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models.Form;
using ToDoListBA.Services;

namespace ToDoListBA.Pages
{
    public partial class TodoAdd
    {
        [Inject] private ITodoApiClient TodoApiClient { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }

        [Inject] IToastService ToastService { get; set; }

        private readonly TodoCreate CreateForm = new();


        private async Task SubmitForm(EditContext context)
        {
            var rs = await TodoApiClient.Insert(CreateForm);
            if(rs is true)
            {
                ToastService.ShowSuccess($"{CreateForm.Name} has been created successfully.", "Ok");
                NavigationManager.NavigateTo("todo-list");
            }
            else
            {
                ToastService.ShowError("Can not add new task", "Error");
            }
        }
    }
 
}
