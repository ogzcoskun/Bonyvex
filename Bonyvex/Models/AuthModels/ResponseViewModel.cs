using Bonyvex.Authentication.api.Models.IdentityModels;

namespace Bonyvex.Authentication.api.Models.AuthModels
{
    public class ResponseViewModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public TokenInfo TokenInfo { get; set; }
    }
}
