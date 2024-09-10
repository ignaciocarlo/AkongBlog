using AkongBlogCore.Domain.Identity;
using AkongBlogInfrastructure.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Admin.User.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<ApplicationUser>>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<ApplicationUser>>
        {
            private readonly IdentityContext _identityContext;
            public GetUsersQueryHandler(IdentityContext identityContext)
            {
                _identityContext = identityContext;
            }

            public async Task<IEnumerable<ApplicationUser>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
            {
                return await _identityContext.Users
                    .IgnoreQueryFilters()
                    .AsNoTracking()
                    .ToListAsync();
            }
        }
    }
}
