using Bonyvex.Authentication.api.Models.AuthModels;
using MediatR;

namespace Bonyvex.Authentication.api.Commands
{
    public class LoginCommand : IRequest<ResponseViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
