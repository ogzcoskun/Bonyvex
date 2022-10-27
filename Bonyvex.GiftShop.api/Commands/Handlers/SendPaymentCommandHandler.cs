using Bonyvex.GiftShop.api.Models;
using Bonyvex.GiftShop.api.Services.PaymentService;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bonyvex.GiftShop.api.Commands.Handlers
{
    public class SendPaymentCommandHandler : IRequestHandler<SendPaymentCommand, ServiceResponse>
    {
        private readonly IPaymentService _paymentService;

        public SendPaymentCommandHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        public async Task<ServiceResponse> Handle(SendPaymentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var paymentResponse = await _paymentService.SendPayment(request.Payment);

                return paymentResponse;

            }catch(Exception ex)
            {
                return new ServiceResponse()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
