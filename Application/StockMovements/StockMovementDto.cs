using System;
using Domain;

namespace Application.StockMovements
{
    public class StockMovementDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int CurrentStock { get; set; }
        public OperationType Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}