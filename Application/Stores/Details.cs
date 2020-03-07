using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Stores
{
    public class Details
    {
        public class Query : IRequest<Store>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Store>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Store> Handle(Query request, CancellationToken cancellationToken)
            {
                var store = await _context.Stores.FindAsync(request.Id);

                if (store == null)
                    throw new RestException(HttpStatusCode.NotFound, new { activity = "Not found" });

                return store;
            }
        }
    }
}