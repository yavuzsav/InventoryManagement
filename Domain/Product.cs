using System;

namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }

        public virtual Category Category { get; set; }
        public virtual Store Store { get; set; }
    }
}