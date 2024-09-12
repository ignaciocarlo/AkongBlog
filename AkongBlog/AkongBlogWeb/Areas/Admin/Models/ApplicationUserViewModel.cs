using System.ComponentModel.DataAnnotations;

namespace AkongBlogWeb.Areas.Admin.Models
{
    public record ApplicationUserViewModel : BaseViewModel
    {
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
