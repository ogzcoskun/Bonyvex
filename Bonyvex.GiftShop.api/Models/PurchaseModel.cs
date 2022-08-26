using System;

namespace Bonyvex.GiftShop.api.Models
{
    public class PurchaseModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string ShippingStatus { get; set; }
        public string ProductId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } 
    }
}
