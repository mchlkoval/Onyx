using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Teams
{
    public class MessageTeamMembersCommand
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public string Message { get; set; }

            public Command()
            {

            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var membersToMessage = await context.Teams
                    .Include(x => x.TeamMembers)
                    .Where(x => x.Id == request.Id)
                    .SelectMany(x => x.TeamMembers)
                    .Select(x => x.User.Id)
                    .ToListAsync();

                var messages = new List<Message>();

                foreach(var user in membersToMessage)
                {
                    var message = new Message
                    {
                        DateOfMessage = DateTime.Now,
                        Content = request.Message,
                        UserId = user,
                        IsDeleted = false,
                        From = "TODO: Change this",
                        Id = Guid.NewGuid().ToString()
                    };

                    messages.Add(message);
                }

                await context.Messages.AddRangeAsync(messages);
                var result = await context.SaveChangesAsync();

                if(result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Failed to send message");
            }
        }
    }
}
