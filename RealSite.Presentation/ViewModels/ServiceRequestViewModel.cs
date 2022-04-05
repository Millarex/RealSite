using System.ComponentModel.DataAnnotations;

namespace RealSite.Presentation.ViewModels
{
    public class ServiceRequestViewModel
    {
        [Required]
        public string RequestType { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        public string Organization { get; set; }
        [Required]
        public string ContactPerson { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
