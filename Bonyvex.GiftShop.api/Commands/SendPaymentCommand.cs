using Bonyvex.GiftShop.api.Models;
using MediatR;

namespace Bonyvex.GiftShop.api.Commands
{
    public class SendPaymentCommand : IRequest<ServiceResponse>
    {
        public PaymentModel Payment { get; set; }
    }
}
