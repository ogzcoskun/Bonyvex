using Bonyvex.Authentication.api.Models.AuthModels;
using System.Threading.Tasks;

namespace Bonyvex.Authentication.api.Services
{
    public interface IAuthService
    {
        Task<ResponseViewModel> UserExist(RegisterViewModel model);
        Task<ResponseViewModel> CreateUser(RegisterViewModel model);
        Task<ResponseViewModel> Login(LoginViewModel model);
    }
}
