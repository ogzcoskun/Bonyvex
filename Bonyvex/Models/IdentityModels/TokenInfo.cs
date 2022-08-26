using System;

namespace Bonyvex.Authentication.api.Models.IdentityModels
{
    public class TokenInfo
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
