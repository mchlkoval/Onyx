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

namespace Application.Commands
{
    public class Register 
    {

        public class Command : IRequest<UserViewModel> {
            public string Password { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public UserType UserType { get; set; }
        }

        public class CommandValidator : AbstractValidator<RegisterViewModel>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Password).NotEmpty();
                RuleFor(x => x.Username).NotEmpty();
                RuleFor(x => x.UserType).NotEmpty();
                RuleFor(x => x.Password).Password();
            }
        }

        public class Handler : IRequestHandler<Command, UserViewModel>
        {
            private readonly DataContext context;
            private readonly UserManager<AppUser> manager;
            private readonly IJWTGenerator generator;

            public Handler(DataContext context, UserManager<AppUser> manager, IJWTGenerator generator)
            {
                this.generator = generator;
                this.manager = manager;
                this.context = context;

            }

            public async Task<UserViewModel> Handle(Command request, CancellationToken cancellationToken)
            {
                //TODO: Add Rest Errors

                var user = new AppUser
                {
                    UserName = request.Username,
                    Email = request.Email,
                    UserType = request.UserType
                };

                var result = await manager.CreateAsync(user, request.Password);

                if(result.Succeeded)
                {
                    return new UserViewModel
                    {
                        Username = user.UserName,
                        Token = generator.CreateToken(user),
                        UserType = user.UserType,
                        Email = user.Email
                    };
                }

                throw new Exception("Failed To Register New User");
            }
        }

    }

}
