using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class StockMovement
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public int CurrentStock { get; set; }
        public OperationType Type { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Product Product { get; set; }
    }

    public enum OperationType : byte
    {
        [Display(Name = "Stok Giris")]
        StokGiris = 1,

        [Display(Name = "Stok Çıkış")]
        StokCikis = 2
    }
}