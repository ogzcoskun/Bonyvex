using Bonyvex.Authentication.api.Data;
using Bonyvex.Authentication.api.Library;
using Bonyvex.Authentication.api.Models.AuthModels;
using Bonyvex.Authentication.api.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Bonyvex.Authentication.api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly AuthDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(AuthDbContext context, IConfiguration config, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _config = config;
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ResponseViewModel> CreateUser(RegisterViewModel model)
        {
            ApplicationUser user = new ApplicationUser()
            {
                FullName = model.FullName,
                Email = model.Email.Trim(),
                UserName = model.Email.Trim()
            };

            var response = new ResponseViewModel();

            IdentityResult result = await _userManager.CreateAsync(user, model.Password.Trim());


            if (result.Succeeded)
            {
                bool roleExists = await _roleManager.RoleExistsAsync(_config["Roles:User"]);

                if (!roleExists)
                {
                    IdentityRole role = new IdentityRole(_config["Roles:User"]);
                    role.NormalizedName = _config["Roles:User"];

                    _roleManager.CreateAsync(role).Wait();
                }

                //Kullanıcıya ilgili rol ataması yapılır.
                _userManager.AddToRoleAsync(user, _config["Roles:User"]).Wait();

                response.IsSuccess = true;
                response.Message = "User Created Successfully.";
            }
            else
            {
                response.IsSuccess = false;
                response.Message = string.Format("An Error occured while trying to create User!!! ....", result.Errors.FirstOrDefault().Description);
            }

            var userOut = await _userManager.FindByNameAsync(model.Email);

            

            return response;
        }

        public async Task<ResponseViewModel> Login(LoginViewModel model)
        {
            var response = new ResponseViewModel();

            ApplicationUser user = await _userManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                response.IsSuccess = false;
                response.Message = "Given email doesn't exist in database!!";
                return response;
            }

            SignInResult signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (signInResult.Succeeded == false)
            {
                response.IsSuccess = false;
                response.Message = "Given credentials are wrong!!!";
                return response;
            }

            ApplicationUser applicationUser = _context.Users.FirstOrDefault(x => x.Id == user.Id);

            AccessTokenGenerator accessTokenGenerator = new AccessTokenGenerator(_context, _config, applicationUser);

            ApplicationUserTokens userTokens = accessTokenGenerator.GetToken();

            response.IsSuccess = true;
            response.Message = "Kullanıcı giriş yaptı.";
            response.TokenInfo = new TokenInfo
            {
                Token = userTokens.Value,
                ExpireDate = userTokens.ExpireDate
            };

            return response;
        }

        public async Task<ResponseViewModel> UserExist(RegisterViewModel model)
        {
            ApplicationUser existsUser = await _userManager.FindByNameAsync(model.Email);

            var response = new ResponseViewModel();

            if (existsUser != null)
            {
                response.IsSuccess = false;
                response.Message = "User Already Exist!!!";

                return response;
            }


            return new ResponseViewModel();
        }
    }
}
