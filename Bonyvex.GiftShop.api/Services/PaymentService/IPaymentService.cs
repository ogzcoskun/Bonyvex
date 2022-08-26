using Bonyvex.GiftShop.api.Models;
using System.Threading.Tasks;

namespace Bonyvex.GiftShop.api.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<ServiceResponse> SendPayment(PaymentModel payment);
    }
}
