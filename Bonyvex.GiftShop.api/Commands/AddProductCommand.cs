using Bonyvex.GiftShop.api.Models;
using MediatR;

namespace Bonyvex.GiftShop.api.Commands
{
    public class AddProductCommand : IRequest<ServiceResponse>
    {
        public ProductModel Product { get; set; }
    }
}
