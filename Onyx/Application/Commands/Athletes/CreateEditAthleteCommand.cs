using Domain.Identity;
using Domain.JoinTables;
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
using ViewModels.Athlete;

namespace Application.Commands.Athletes
{
    public class CreateEditAthleteCommand
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public GenderType Gender { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Address { get; set; }
            public string Address2 { get; set; }
            public int Weight { get; set; }
            public int Age { get; set; }
            public DateTime DateOfBirth { get; set; }
            public IEnumerable<AssignedCoachViewModel> AssignedCoaches { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            private async Task EditAthlete(Command request)
            {
                var athlete = await context.Users
                    .Include(x => x.AssignedCoaches)
                    .SingleAsync(x => x.Id == request.Id);
                athlete.Name = request.Name;
                athlete.Gender = request.Gender;
                athlete.City = request.City;
                athlete.State = request.State;
                athlete.Country = request.Country;
                athlete.Address = request.Address;
                athlete.Address2 = request.Address2;
                athlete.Weight = request.Weight;
                athlete.Age = request.Age;
                athlete.DateOfBirth = request.DateOfBirth;

                try
                {
                   
                    athlete.AssignedCoaches = request.AssignedCoaches.Select(x => new CoachAthlete
                    {
                        AthleteId = athlete.Id,
                        CoachId = x.Id
                    }).ToList();

                    context.Users.Update(athlete);
                    var result = await context.SaveChangesAsync();

                    if (result < 0)
                    {
                        throw new Exception("Failed to update athlete");
                    }

                    //var newlyAssigned = request.AssignedCoaches.Select(x => new CoachAthlete
                    //{
                    //    AthleteId = athlete.Id,
                    //    CoachId = x.Id
                    //});


                    //var upsertResult = await context.AssignedAthletes.UpsertRange(newlyAssigned)
                    //    .On(x => new { x.AthleteId, x.CoachId})
                    //    .RunAsync();

                    //if(upsertResult < 0)
                    //{
                    //    throw new Exception("Failed to update athlete");
                    //}

                } catch (Exception e)
                {
                    throw;
                }
            }

            private async Task CreateAthlete(Command request)
            {
                var athlete = new AppUser
                {
                    Id = Guid.NewGuid().ToString()
                };
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if(string.IsNullOrEmpty(request.Id))
                {
                    await CreateAthlete(request);
                    return Unit.Value;
                } else
                {
                    await EditAthlete(request);
                    return Unit.Value;
                }
            }
        }
    }
}
