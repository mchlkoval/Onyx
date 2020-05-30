using MediatR;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Athletes
{
    public class UpdateAthleteStatusCommand 
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
            public bool Activate { get; set; }

            public Command(string id, bool activate)
            {
                this.Id = id;
                this.Activate = activate;
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
                var user = context.Users.Single(x => x.Id == request.Id);
                user.IsActive = request.Activate;

                context.Users.Update(user);

                var result = await context.SaveChangesAsync();

                if(result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Failed to update athlete status");
            }
        }
    }
}
