namespace OMoney.Web.Api.Models
{
    public class ResetPasswordViewModel
    {
        public string userId { get; set; }
        public string code { get; set; }
        public string newPassword { get; set; }
        public string confirmNewPassword { get; set; }
    }
}