using Bonyvex.Authentication.api.Models.AuthModels;
using MediatR;

namespace Bonyvex.Authentication.api.Commands
{
    public class RegisterCommand : IRequest<ResponseViewModel>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
