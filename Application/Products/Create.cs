using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using MediatR;
using Persistence;

namespace Application.Products
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public Guid CategoryId { get; set; }
            public Guid StoreId { get; set; }
            public string Name { get; set; }
            public string Barcode { get; set; }
            public string QuantityPerUnit { get; set; }
            public decimal UnitPrice { get; set; }
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
                var category = await _context.Categories.FindAsync(request.CategoryId);

                if (category == null)
                    throw new RestException(HttpStatusCode.NotFound, new { category = "Not found" });

                var store = await _context.Stores.FindAsync(request.StoreId);

                if (store == null)
                    throw new RestException(HttpStatusCode.NotFound, new { store = "Not found" });

                var product = new Product
                {
                    Id = request.Id,
                    CategoryId = request.CategoryId,
                    StoreId = request.StoreId,
                    Name = request.Name,
                    Barcode = request.Barcode,
                    QuantityPerUnit = request.QuantityPerUnit,
                    UnitPrice = request.UnitPrice,
                };

                _context.Products.Add(product);

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;

                throw new Exception("Problem saving changes");
            }
        }
    }
}