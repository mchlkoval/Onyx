using Domain;
using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Athletes
{
    public class MessageAthleteCommand
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
                    IsDeleted = false,
                    From = request.Id,
                    Id = Guid.NewGuid().ToString()
                };

                await context.Messages.AddAsync(message);
                var result = await context.SaveChangesAsync();

                Console.WriteLine("Result: ", result);

                if(result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Failed to send message");
            }
        }
    }
}
