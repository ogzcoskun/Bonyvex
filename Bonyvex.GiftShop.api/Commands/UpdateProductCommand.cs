using Bonyvex.GiftShop.api.Models;
using MediatR;

namespace Bonyvex.GiftShop.api.Commands
{
    public class UpdateProductCommand : IRequest<ServiceResponse>
    {
        public ProductModel UpdatedProduct { get; set; }

    }
}
