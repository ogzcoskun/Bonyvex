using Bonyvex.GiftShop.api.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bonyvex.GiftShop.api.Commands.Handlers
{
    public class SendPaymentCommandHandler : IRequestHandler<SendPaymentCommand, ServiceResponse>
    {
        public SendPaymentCommandHandler()
        {

        }
        public Task<ServiceResponse> Handle(SendPaymentCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
