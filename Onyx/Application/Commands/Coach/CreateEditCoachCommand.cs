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
                    await CreateCoach(request);
                } else
                {
                    await EditCoach(request);
                }

                return Unit.Value;
            }

            private async Task SendEmail(string coachName, string userName)
            {
                var messageToSend = new MimeMessage
                {
                    Sender = new MailboxAddress("Onyx Test Message", "mchlkovalsky@outlook.com"),
                    Subject = "User Created",
                    Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                    {
                        Text = $"We've successfully created a new coach with the username of {userName} and a name of {coachName} \n" +
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

            private async Task CreateCoach(Command request)
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
                    Age = (int)(DateTime.Now - request.DateOfBirth).TotalDays/365,   
                    AssignedAthletes = new List<CoachAthlete>(),
                    AssignedCoaches = new List<CoachAthlete>()
                };

                try
                {
                    //first we add the coach
                    await userManager.CreateAsync(coach, "Pa$$w0rd");
                    if(request.AssignedAthletes != null)
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
                            throw new Exception("Failed to create coach");
                        }
                    }

                    await SendEmail(coach.Name, coach.UserName);

                } catch (Exception e)
                {
                    throw;
                }
                
            }

            private async Task EditCoach(Command request)
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
