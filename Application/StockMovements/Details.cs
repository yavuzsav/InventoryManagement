using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.StockMovements
{
    public class Details
    {
        public class Query : IRequest<StockMovementDto>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, StockMovementDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<StockMovementDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var stockMovement = await _context.StockMovements.FindAsync(request.Id);

                if (stockMovement == null)
                    throw new RestException(HttpStatusCode.NotFound, new { stockMovement = "Not found" });

                return _mapper.Map<StockMovement, StockMovementDto>(stockMovement);
            }
        }
    }
}