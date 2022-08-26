using Bonyvex.GiftShop.api.Models;
using System.Threading.Tasks;
using Iyzipay.Model;
using Iyzipay.Request;
using System.Collections.Generic;
using Iyzipay;

namespace Bonyvex.GiftShop.api.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        public async Task<ServiceResponse> SendPayment(PaymentModel payment)
        {

            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            request.Price = "1"; // Tutar
            request.PaidPrice = "1.1";
            request.Currency = Currency.TRY.ToString();
            request.BasketId = "B67832";
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = "http:/<Iyzico Api Geri Dönüş Adresi>/OdemeSonucu";

            PaymentCard paymentCard = new PaymentCard()
            {
                CardHolderName = "John Doe",
                CardNumber = "5528790000000008",
                ExpireMonth = "12",
                ExpireYear = "2030",
                Cvc = "123",
                RegisterCard = 0,
                
            };
            request.PaymentCard = paymentCard;

            Options options = new Options();
            options.ApiKey = "sandbox-......"; //Iyzico Tarafından Sağlanan Api Key
            options.SecretKey = "sandbox-..."; //Iyzico Tarafından Sağlanan Secret Key
            options.BaseUrl = "https://sandbox-api.iyzipay.com";

            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);

            return new ServiceResponse();
        }
    }
}
