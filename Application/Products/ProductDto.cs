using System;

namespace Application.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}