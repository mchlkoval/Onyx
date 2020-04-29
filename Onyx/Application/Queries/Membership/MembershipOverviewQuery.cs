using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Membership;

namespace Application.Queries.Membership
{
    public class MembershipOverviewQuery
    {
        public class Query : IRequest<List<MembershipOverviewViewModel>>
        {

        }

        public class Handler : IRequestHandler<Query, List<MembershipOverviewViewModel>>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<List<MembershipOverviewViewModel>> Handle(Query request, CancellationToken cancellationToken)
            {
                var vm = await context.Memberships.Select(x => new MembershipOverviewViewModel {
                    Description = x.Description,
                    Name = x.Name,
                    Id = x.Id
                }).ToListAsync();

                return vm;
            }
        }
    }
}
