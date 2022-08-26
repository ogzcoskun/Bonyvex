using Microsoft.AspNetCore.Http;
using System;

namespace Bonyvex.GiftShop.api.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; } 
    }
}
