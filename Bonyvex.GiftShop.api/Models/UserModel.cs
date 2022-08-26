namespace Bonyvex.GiftShop.api.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public AddressModel  AddressModel { get; set; }

    }
}
