using AkongBlogInfrastructure.Infrastructure.Data;
using Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Admin.User.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<ApplicationUserDto>>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<ApplicationUserDto>>
        {
            private readonly IdentityContext _identityContext;
            public GetUsersQueryHandler(IdentityContext identityContext)
            {
                _identityContext = identityContext;
            }

            public async Task<IEnumerable<ApplicationUserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                return await _identityContext.Users.AsNoTracking()
                    .Select(a => new ApplicationUserDto()
                    {
                        Id = a.Id,
                        UserName = a.UserName!,
                        Email = a.Email!,
                    }).ToListAsync();
            }
        }
    }
}
