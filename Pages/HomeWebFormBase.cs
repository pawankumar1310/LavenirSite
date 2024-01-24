using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using Model;
 
namespace LavenirSite.Pages
{
    public class HomeWebFormBase : ComponentBase
    {
        protected string? FirstName { get; set; }
        protected string? LastName { get; set; }
        protected string? UserPhotoDisplay { get; set; }
        protected string? MobileNumber { get; set; }
        protected string? CommunicationAddress { get; set; }
        protected string? FacebookProfile { get; set; }
 
        protected string? TwitterProfile { get; set; }
 
        protected string? LinkedinProfile { get; set; }
 
        protected string? YoutubeChannel { get; set; }
 
        protected string? InstagramProfile { get; set; }
 
        protected string? LyceeProfile { get; set; }
 
 
        protected string? Country { get; set; }
        protected string? State { get; set; }
        protected string? District { get; set; }
        protected string? PinCode { get; set; }
        protected string? ReferredBy { get; set; }
        protected List<string> Countries = new List<string>();
        protected List<string> States = new List<string>();
        protected List<string> Districts = new List<string>();
 
        protected string InputPinCode ;
        protected string zipCodeID;
        protected string countryName ;
 
       protected async void DisplayEnteredPinCode(ChangeEventArgs e)
        {
        string enteredValue = e.Value.ToString();
        if (enteredValue.Length == 6)
        {
            InputPinCode = enteredValue;
           await getDetails();
            Console.WriteLine(InputPinCode);
 
        }
        else if (enteredValue.Length > 6)
        {
            InputPinCode = enteredValue.Substring(0, 6);
        }
        }
 
         public async Task getDetails()
    {
        try
        {
            string pinCode = InputPinCode;
            var apiUrl2 = $"https://localhost:7000/api/UtilityService/GetZipCodeIDbyZipCode/{560037}";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response2 = await httpClient.GetAsync(apiUrl2);
                if (response2.IsSuccessStatusCode)
                {
                    var jsonResponse = await response2.Content.ReadAsStringAsync();
                    zipCodeID = jsonResponse.Trim('"');
                }
                else
                {
                    Console.WriteLine($"Failed to get Zip Code ID. Status code: {response2.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
     
    }
 
    private async Task GetPlaceInformation(string zipCodeID)
{
    string apiUrlForPlaceInfo = $"https://localhost:7000/api/UserService/getAddress/{zipCodeID}";
   
    using (var httpClient = new HttpClient())
    {
        httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        var responseinfo = await httpClient.GetAsync($"{apiUrlForPlaceInfo}");
       
        if (responseinfo.IsSuccessStatusCode)
        {
            var jsonResponse = await responseinfo.Content.ReadAsStringAsync();
            var placeInformationList = JsonConvert.DeserializeObject<PlaceInformationModel>(jsonResponse);
 
            // Set the values to the corresponding properties in your component
            Country = placeInformationList.countryName;
            State = placeInformationList.stateName;
            District = placeInformationList.cityName;
 
            // Update the UI as needed
            StateHasChanged();
        }
        else
        {
            Console.WriteLine($"Failed to get place information. Status code: {responseinfo.StatusCode}");
        }
    }
}
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
           var imageFile = e.File;
       
        // Process the file as needed, e.g., upload it to the server and get the URL
        // For simplicity, we'll just set the UserPhotoUrl to a base64 representation of the image
        var buffer = new byte[imageFile.Size];
        await imageFile.OpenReadStream().ReadAsync(buffer);
        UserPhotoDisplay = $"data:{imageFile.ContentType};base64,{Convert.ToBase64String(buffer)}";
        }
 
        protected async Task Register()
        {
 
        }
        protected string? Email { get; set; }
        protected string? Username { get; set; }
        public string AreaCityStateNation { get; private set; }
 
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