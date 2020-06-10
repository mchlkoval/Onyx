using Domain.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Athletes
{
    public class CreateEditAthleteCommand
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public GenderType Gender { get; set; }
            public UserType UserType { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Address { get; set; }
            public string Address2 { get; set; }
            public int Weight { get; set; }
            public int Age { get; set; }
            public DateTime DateOfBirth { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            private async void EditAthlete(Command request)
            {
                var athlete = await context.Users.SingleAsync(x => x.Id == request.Id);
            }

            private void CreateAthlete(Command request)
            {
                var athlete = new AppUser
                {

                };
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if(string.IsNullOrEmpty(request.Id))
                {
                    CreateAthlete(request);
                    return Unit.Value;
                } else
                {

                }

                return Unit.Value;
            }
        }
    }
}
