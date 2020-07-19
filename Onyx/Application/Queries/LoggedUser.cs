using Application.Interfaces.JWT;
using Application.Interfaces.User;
using Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.User;

namespace Application.Queries
{
    public class LoggedUser
    {
        public class Query : IRequest<UserViewModel> { }

        public class Handler : IRequestHandler<Query, UserViewModel>
        {
            private readonly UserManager<AppUser> manager;
            private readonly IJWTGenerator generator;
            private readonly IUserAccessor accessor;
            public Handler(UserManager<AppUser> manager, IJWTGenerator generator, IUserAccessor accessor)
            {
                this.accessor = accessor;
                this.generator = generator;
                this.manager = manager;
            }

            public async Task<UserViewModel> Handle(Query request, CancellationToken ct)
            {
                var loggedInUser = await manager.FindByNameAsync(accessor.GetCurrentUserName());

                return new UserViewModel
                {
                    Id = loggedInUser.Id,
                    OrgId = loggedInUser.OrganizationId,
                    Email = loggedInUser.Email,
                    Token = generator.CreateToken(loggedInUser),
                    Username = loggedInUser.UserName,
                    UserType = loggedInUser.UserType
                };
            }
        }
    }
}
