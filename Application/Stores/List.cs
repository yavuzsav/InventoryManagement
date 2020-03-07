using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Stores
{
    public class List
    {
        public class Query : IRequest<List<Store>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Store>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Store>> Handle(Query request, CancellationToken cancellationToken)
            {
                var stores = await _context.Stores.ToListAsync();

                return stores;
            }
        }
    }
}