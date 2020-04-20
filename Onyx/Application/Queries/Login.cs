using Application.Interfaces.JWT;
using Application.Validators;
using Domain.Identity;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence.Context;
using Shared.Enumerations;
using System;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.User;

namespace Application.Queries
{
    public class Login 
    {
        public class Query : IRequest<UserViewModel>
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Username).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, UserViewModel>
        {
            private readonly UserManager<AppUser> userManager;
            private readonly SignInManager<AppUser> signInManager;
            private readonly IJWTGenerator generator;

            public Handler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJWTGenerator generator)
            {
                this.generator = generator;
                this.signInManager = signInManager;
                this.userManager = userManager;
            }

            public async Task<UserViewModel> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await userManager.FindByNameAsync(request.Username);

                //if (user == null)
                //{
                //    throw new RestException(HttpStatusCode.Unauthorized);
                //}

                var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (result.Succeeded)
                {
                    //TODO return token to user
                    return new UserViewModel
                    {
                        Token = generator.CreateToken(user),
                        Username = user.UserName,
                        Email = user.Email,
                        UserType = user.UserType
                    };
                }

                //throw new RestException(HttpStatusCode.Unauthorized);
                throw new Exception("Failed to log in");
            }
        }
    }

}

