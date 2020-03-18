using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.StockMovements
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
            public int Type { get; set; }
            public DateTime CreatedAt { get; set; }

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
                var product = await _context.Products.FindAsync(request.ProductId);

                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound, new { product = "Not found" });

                if (!(request.Type == 1 || request.Type == 2))
                    throw new RestException(HttpStatusCode.NotFound, new { type = "Stok Giriş = 1, Stok Çıkış = 2" });

                product.UnitsInStock = product.UnitsInStock + request.Quantity;

                var stockMovement = new StockMovement
                {
                    Id = request.Id,
                    ProductId = request.ProductId,
                    CurrentStock = product.UnitsInStock,
                    Quantity = request.Quantity,
                    Type = (OperationType)request.Type,
                    CreatedAt = DateTime.Now
                };

                _context.StockMovements.Add(stockMovement);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}