using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;

namespace Application.Stores
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Province { get; set; }
            public string District { get; set; }
            public string Address { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var store = await _context.Stores.FindAsync(request.Id);

                if (store == null)
                    throw new RestException(HttpStatusCode.NotFound, new {store = "Not found"});

                store.Name = request.Name ?? store.Name;
                store.Province = request.Province ?? store.Province;
                store.District = request.District ?? store.District;
                store.Address = request.Address ?? store.Address;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}