using AkongBlogCore.Domain.Identity;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AkongBlogWeb.Areas.Admin.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public IndexModel(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public IList<ApplicationUser> ApplicationUsers { get; set; }
    }
}
