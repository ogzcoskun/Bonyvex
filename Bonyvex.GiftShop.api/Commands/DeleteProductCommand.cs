using Bonyvex.GiftShop.api.Models;
using MediatR;

namespace Bonyvex.GiftShop.api.Commands
{
    public class DeleteProductCommand : IRequest<ServiceResponse>
    {
        public string ProductId { get; set; }
    }
}
