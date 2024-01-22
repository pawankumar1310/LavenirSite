// LoginWebForm.razor.cs

using Microsoft.AspNetCore.Components;

namespace LavenirSite.Pages
{
    public class LoginWebFormBase : ComponentBase
    {
        protected string? Email { get; set; }
        protected string? MailOTP { get; set; }
        protected bool IsOTPVerificationDisabled { get; set; } = false;
        protected bool IsOTPVerificationFailed { get; set; } = false;
        protected string ButtonLabel { get; set; } = "Send OTP";

        protected void SendOTP()
        {
            // Add your logic here to handle sending OTP
            // You can use Email and MailOTP properties

            // Example:
            if (Email == "example@email.com" && MailOTP == "123456")
            {
                // OTP verification succeeded
                // Add your logic here
            }
            else
            {
                // OTP verification failed
                IsOTPVerificationFailed = true;
            }
        }
    }
}

