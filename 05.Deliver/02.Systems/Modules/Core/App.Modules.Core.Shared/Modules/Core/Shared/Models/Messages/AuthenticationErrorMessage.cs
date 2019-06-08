namespace App.Modules.Core.Shared.Models.Messages
{
    public class AuthenticationErrorMessage
    {
        public string Error { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorUri { get; set; }
    }
}