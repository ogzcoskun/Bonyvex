using Bonyvex.Authentication.api.Models.AuthModels;
using Bonyvex.Authentication.api.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Bonyvex.Authentication.api.Commands.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseViewModel>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<ResponseViewModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var loginInfo = new LoginViewModel()
            {
                Email = request.Email,
                Password = request.Password,
            };

            var response = await _authService.Login(loginInfo);

            return response;
        }
    }
}
