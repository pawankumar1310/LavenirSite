using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace LavenirSite.Pages
{
    public class HomeWebFormBase : ComponentBase
    {
        protected string? FirstName { get; set; }
        protected string? LastName { get; set; }
        protected string? UserPhotoDisplay { get; set; } = ""; // Set the default path or leave it empty
        protected string? MobileNumber { get; set; }
        protected string? CommunicationAddress { get; set; }
        protected string? FacebookProfile { get; set; }

        protected string? TwitterProfile { get; set; }

        protected string? LinkedinProfile { get; set; }

        protected string? YoutubeChannel { get; set; }

        protected string? InstagramProfile { get; set; }

        protected string? LyceeProfile { get; set; }


        protected string? SelectedCountry { get; set; }
        protected string? SelectedState { get; set; }
        protected string? SelectedDistrict { get; set; }
        protected string? PinCode { get; set; }
        protected string? ReferredBy { get; set; }
        protected List<string> Countries = new List<string>();
        protected List<string> States = new List<string>();
        protected List<string> Districts = new List<string>();
        protected void GetState()
        {
            // Implement logic to fetch states based on the selected country
        }

        protected void GetDistrict()
        {
            // Implement logic to fetch districts based on the selected state
        }

        protected async Task HandleFileUpload(InputFileChangeEventArgs e)
        {
            var file = e.File;
            // Implement logic to handle file upload, save the file, and update UserPhotoDisplay
        }

        protected async Task Register()
        {

        }
        protected string? Email { get; set; }
        protected string? Username { get; set; }

        public void NavigateTo(string page)
        {
            // Add navigation logic here, for example:
            // NavigationManager.NavigateTo($"/{page}");
        }

        public void HandleParticipantTypeChange(ChangeEventArgs args)
        {
            // Handle the participant type change here
        }

        public void Logout()
        {
            // Handle logout logic here
        }

        // Add any additional logic as needed
    }
}