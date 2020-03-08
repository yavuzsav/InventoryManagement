using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;

namespace Application.Products
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public Guid? CategoryId { get; set; }
            public Guid? StoreId { get; set; }
            public string Name { get; set; }
            public string Barcode { get; set; }
            public string QuantityPerUnit { get; set; }
            public decimal? UnitPrice { get; set; }
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
                var product = await _context.Products.FindAsync(request.Id);

                if (product == null)
                    throw new RestException(HttpStatusCode.NotFound, new { product = "Not found" });

                product.CategoryId = request.CategoryId == null ? product.CategoryId : request.CategoryId.Value;
                product.StoreId = request.StoreId == null ? product.StoreId : request.StoreId.Value;
                product.Name = request.Name ?? product.Name;
                product.Barcode = request.Barcode ?? product.Barcode;
                product.QuantityPerUnit = request.QuantityPerUnit ?? product.QuantityPerUnit;
                product.UnitPrice = request.UnitPrice == null ? product.UnitPrice : request.UnitPrice.Value;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}