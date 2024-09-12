using AkongBlogWeb.Areas.Admin.Models;
using AkongBlogWeb.Models;
using Application.Features.Admin.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AkongBlogWeb.Areas.Admin.Pages.User
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;
        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }
        public ApplicationUserViewModel? ApplicationUser { get; set; }
        public DataTableResponse? DataTableResponse { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostListAll()
        {
            var users = await _mediator.Send(new GetUsersQuery());
            DataTableResponse = new DataTableResponse()
            {
                RecordsTotal = users.Count(),
                RecordsFiltered = 10, // You may need to adjust this based on your filtering logic
                Data = users.ToArray()
            };
            return new JsonResult(new
            {
                recordsTotal = DataTableResponse.RecordsTotal,
                recordsFiltered = DataTableResponse.RecordsFiltered,
                data = DataTableResponse.Data
            });
        }
    }
}
