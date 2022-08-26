namespace Bonyvex.GiftShop.api.Models
{
    public class CreditCardModel
    {
        public string FullName { get; set; }
        public string CardNo { get; set; }
        public string ExpireDate { get; set; }
        public int Cvc { get; set; }
    }
}
