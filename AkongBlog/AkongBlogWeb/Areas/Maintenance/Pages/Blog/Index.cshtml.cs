using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AkongBlogWeb.Areas.Maintenance.Pages.Blog
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPostListAllAsync()
        {
            return Page();
        }
    }
}
