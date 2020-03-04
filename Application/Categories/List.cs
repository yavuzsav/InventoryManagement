using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Categories
{
    public class List
    {
        public class Query : IRequest<List<Category>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Category>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Category>> Handle(Query request, CancellationToken cancellationToken)
            {
                var categories = await _context.Categories.ToListAsync();

                return categories;
            }
        }
    }
}