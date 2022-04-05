using System.ComponentModel.DataAnnotations;

namespace RealSite.Presentation.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
