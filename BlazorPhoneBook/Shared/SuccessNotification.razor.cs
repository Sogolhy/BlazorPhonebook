using Microsoft.AspNetCore.Components;

namespace BlazorPhoneBook.Shared
{
    public partial class SuccessNotification
    {
        public string _modalDisplay;
        public string _modalClass;
        public bool _showBackdrop;

        [Inject]
        public NavigationManager Navigation { get; set; }

        public void Show()
        {
            _modalDisplay = "block;";
            _modalClass = "show";
            _showBackdrop = true;
            StateHasChanged();
        }

        private void Hide()
        {
            _modalDisplay = "none;";
            _modalClass = "";
            _showBackdrop = false;
            StateHasChanged();
        }
    }
}
