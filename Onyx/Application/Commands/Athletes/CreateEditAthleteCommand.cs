using Domain.Identity;
using Domain.JoinTables;
using MailKit.Net.Smtp;
using MailKit.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MimeKit;
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
            private UserManager<AppUser> manager;

            public Handler(DataContext context, UserManager<AppUser> manager)
            {
                this.context = context;
                this.manager = manager;
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

                } catch (Exception e)
                {
                    throw;
                }
            }

            private async Task CreateAthlete(Command request)
            {
                var athleteId = Guid.NewGuid().ToString();
                var numberOfAthletes = await context.Users.CountAsync();
                var athlete = new AppUser
                {
                    Id = athleteId,
                    Gender = request.Gender,
                    UserName = $"temporary_{numberOfAthletes}",
                    UserType = UserType.Athlete,
                    DateJoined = DateTime.Now,
                    Name = request.Name,
                    IsActive = true,
                    //temp for now
                    OrganizationId = "3c084a85-e680-40c1-9c2c-d5839286ec67",
                    City = request.City,
                    State = request.State,
                    Country = request.Country,
                    Address = request.Address,
                    Address2 = request.Address2,
                    Weight = request.Weight,
                    Age = (int) DateTime.Now.Subtract(request.DateOfBirth).TotalDays/365,
                    DateOfBirth = request.DateOfBirth,
                    ExerciseLogs = new List<Domain.Workouts.ExerciseLog>(),
                    AssignedCoaches = request.AssignedCoaches.Select(x => new CoachAthlete {
                        AthleteId = athleteId,
                        CoachId = x.Id
                    }).ToList(),
                    Messages = new List<Domain.Message>(),

                };

                var result = await manager.CreateAsync(athlete, "Pa$$w0rd");
                if (!result.Succeeded)
                {
                    throw new Exception("Failed to create athlete");
                }

                await SendEmail(athlete.Name, athlete.UserName);
            }

            private async Task SendEmail(string athleteName, string userName)
            {
                var messageToSend = new MimeMessage
                {
                    Sender = new MailboxAddress("Onyx Test Message", "mchlkovalsky@outlook.com"),
                    Subject = "User Created",
                    Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                    {
                        Text = $"We've successfully created a new athlete with the username of {userName} and a name of {athleteName} \n" +
                        $"The temporary password is: Pa$$w0rd. Please make sure they change their password as soon as possible"
                    }
                };

                messageToSend.From.Add(new MailboxAddress("Michael Kovalsky", "mchlkovalsky@outlook.com"));
                messageToSend.To.Add(new MailboxAddress("Michael Kovalsky", "mchlkovalsky@gmail.com"));

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.live.com", 587, SecureSocketOptions.StartTls);
                    smtp.Authenticate("mchlkovalsky@outlook.com", "Jaljap2732!");
                    await smtp.SendAsync(messageToSend);
                    await smtp.DisconnectAsync(true);
                }
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
