using Domain.Identity;
using Domain.JoinTables;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewModels.Coach;

namespace Application.Commands.Coach
{
    public class CreateEditCoachCommand
    {
        public class Command : DetailedCoachViewModel, IRequest<Unit>
        {
            public Command() : base()
            {
                
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private DataContext context;
            private UserManager<AppUser> userManager;

            public Handler(DataContext context, UserManager<AppUser> userManager)
            {
                this.context = context;
                this.userManager = userManager;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                
                if(string.IsNullOrEmpty(request.Id))
                {
                    CreateCoach(request);
                } else
                {
                    EditCoach(request);
                }

                return Unit.Value;
            }

            private async void CreateCoach(Command request)
            {
                var numberOfCoaches = context.Users
                    .Where(x => x.UserType == UserType.Coach)
                    .Where(x => x.OrganizationId == "3c084a85-e680-40c1-9c2c-d5839286ec67")
                    .Count();

                var coach = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name,
                    OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                    UserName = $"temporary_{numberOfCoaches}",
                    Email = request.Email,
                    UserType = UserType.Coach,
                    Gender = request.Gender,
                    DateJoined = request.DateHired,
                    IsActive = true,
                    City = request.City,
                    State = request.State,
                    Country = request.Country,
                    Address = request.Address,
                    Address2 = request.Address2,
                    DateOfBirth = request.DateOfBirth,
                    Age = (int)(DateTime.Now - request.DateOfBirth).TotalDays/365
                };

                try
                {
                    //first we add the coach
                    await userManager.AddPasswordAsync(coach, "Pa$$w0rd");

                    coach.AssignedAthletes = request.AssignedAthletes.Select(x => new CoachAthlete
                    {
                        AthleteId = x.AthleteId,
                        CoachId = coach.Id
                    }).ToList();

                    context.Users.Update(coach);

                    var result = await context.SaveChangesAsync();

                    if(result < 0)
                    {
                        throw new Exception("Failed to create coach");
                    }
                } catch (Exception e)
                {
                    throw;
                }
                
            }

            private async void EditCoach(Command request)
            {
                var coach = await context.Users
                    .Include(x => x.AssignedAthletes)
                    .SingleAsync(x => x.Id == request.Id);

                coach.Name = request.Name;
                coach.Email = request.Email;
                coach.City = request.City;
                coach.State = request.State;
                coach.Country = request.Country;
                coach.Address = request.Address;
                coach.Address2 = request.Address2;
                coach.Gender = request.Gender;
                coach.DateJoined = request.DateHired;
                coach.DateOfBirth = request.DateOfBirth;

                try
                {
                    coach.AssignedAthletes = request.AssignedAthletes.Select(x => new CoachAthlete
                    {
                        AthleteId = x.AthleteId,
                        CoachId = coach.Id
                    }).ToList();

                    context.Users.Update(coach);
                    var result = await context.SaveChangesAsync();

                    if(result < 0)
                    {
                        throw new Exception("Failed to update coach");
                    }
                } catch (Exception e)
                {
                    throw;
                }
                
            }
        }
    }
}
