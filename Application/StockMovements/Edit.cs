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
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public Guid? ProductId { get; set; }
            public int? Quantity { get; set; }
            public int? Type { get; set; }
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
                var stockMovement = await _context.StockMovements.FindAsync(request.Id);

                if (stockMovement == null)
                    throw new RestException(HttpStatusCode.NotFound, new { stockMovement = "Not found" });

                if (!(request.Type == 1 || request.Type == 2))
                    throw new RestException(HttpStatusCode.NotFound, new { type = "Stok Giriş = 1, Stok Çıkış = 2" });

                var oldProduct = await _context.Products.FindAsync(stockMovement.ProductId);
                oldProduct.UnitsInStock = oldProduct.UnitsInStock - stockMovement.Quantity;

                if (request.ProductId != null)
                {
                    var product = await _context.Products.FindAsync(request.ProductId);

                    if (product == null)
                        throw new RestException(HttpStatusCode.NotFound, new { product = "Not found" });
                }

                stockMovement.ProductId = request.ProductId ?? stockMovement.ProductId;
                stockMovement.Quantity = request.Quantity ?? stockMovement.Quantity;
                stockMovement.Type = request.Type == null ? stockMovement.Type : (OperationType)request.Type.Value;
                stockMovement.CreatedAt = DateTime.Now;
                stockMovement.Product.UnitsInStock = stockMovement.Product.UnitsInStock + stockMovement.Quantity;
                stockMovement.CurrentStock = stockMovement.Product.UnitsInStock;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}