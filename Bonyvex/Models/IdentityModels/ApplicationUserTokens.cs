using Microsoft.AspNetCore.Identity;
using System;

namespace Bonyvex.Authentication.api.Models.IdentityModels
{
    public class ApplicationUserTokens : IdentityUserToken<string>
    {
        public DateTime ExpireDate { get; set; }
    }
}
