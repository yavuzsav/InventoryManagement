using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.StockMovements
{
    public class List
    {
        public class Query : IRequest<List<StockMovementDto>>
        {
            public string Predicate { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<StockMovementDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<List<StockMovementDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.StockMovements.AsQueryable();
                var stockMovements = new List<StockMovement>();

                switch (request.Predicate)
                {
                    case "giris":
                        stockMovements = await queryable.Where(x => x.Type == OperationType.StokGiris).ToListAsync();
                        break;
                    case "cikis":
                        stockMovements = await queryable.Where(x => x.Type == OperationType.StokCikis).ToListAsync();
                        break;
                    default:
                        stockMovements = await queryable.ToListAsync();
                        break;
                }

                return _mapper.Map<List<StockMovement>, List<StockMovementDto>>(stockMovements);
            }
        }
    }
}