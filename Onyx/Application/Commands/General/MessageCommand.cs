using Domain;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.General
{
    public class MessageCommand
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
                var message = new Message
                {
                    DateOfMessage = DateTime.Now,
                    Content = request.Message,
                    UserId = request.Id,
                    IsDeleted = false,
                    From = "TODO: Change this",
                    Id = Guid.NewGuid().ToString()
                };

                await context.Messages.AddAsync(message);
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
