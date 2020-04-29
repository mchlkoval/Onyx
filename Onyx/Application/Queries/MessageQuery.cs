using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class MessageQuery
    {
        public class Query : IRequest<List<Message>>
        {

        }

        public class Handler : IRequestHandler<Query, List<Message>>
        {
            private DataContext context;

            public Handler(DataContext context)
            {
                this.context = context;
            }

            public async Task<List<Message>> Handle(Query request, CancellationToken token)
            {
                var messages = await context.Messages.ToListAsync(token);
                return messages;
            }
        }
    }
}
