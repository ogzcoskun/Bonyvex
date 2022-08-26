namespace Bonyvex.GiftShop.api.Models
{
    public class PaymentModel
    {
        public CreditCardModel CreditCard { get; set; }
        public string ProductId { get; set; }
        public UserModel User { get; set; }
    }
}
