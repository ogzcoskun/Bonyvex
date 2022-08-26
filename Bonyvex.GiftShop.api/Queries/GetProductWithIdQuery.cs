using Bonyvex.GiftShop.api.Models;
using MediatR;

namespace Bonyvex.GiftShop.api.Queries
{
    public class GetProductWithIdQuery : IRequest<ProductModel>
    {
        public string Id { get; set; }  
    }
}
