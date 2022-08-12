using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ToDoListBA.Components
{
    public partial class ConfirmComponent
    {
        protected bool ShowConfirm { get; set; }

        [Parameter]
        public string Title { get; set; } = "Confirm Delete?";

        [Parameter]
        public string Messages { get; set; } = "Are you sure want to delete?";

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        public void Show() { ShowConfirm = true;  StateHasChanged(); }

        protected async Task OnConfirmationChanged(bool confirm)
        {
            ShowConfirm = false; // tắt confirm dialog
            await ConfirmationChanged.InvokeAsync(confirm);
        }
    }
}
