using Bonyvex.Authentication.api.Commands;
using Bonyvex.Authentication.api.Models.AuthModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Bonyvex.Authentication.api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            ResponseViewModel responseViewModel = new ResponseViewModel();

            try
            {
                if (!ModelState.IsValid)
                {
                    responseViewModel.IsSuccess = false;
                    responseViewModel.Message = "Given Credentials are missing or incorrect!!!";

                    return BadRequest(responseViewModel);
                }

                var response = await _mediator.Send(new RegisterCommand()
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Password = model.Password,
                    ConfirmPassword = model.ConfirmPassword
                });

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseViewModel()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {

            try
            {
                var response = new ResponseViewModel();

                if (!ModelState.IsValid)
                {
                    response.IsSuccess = false;
                    response.Message =  "Given Credentials are missing or incorrect!!!";
                    return BadRequest(response);
                }

                response = await _mediator.Send(new LoginCommand()
                {
                    Email = model.Email,
                    Password = model.Password
                });

                return Ok(response);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



    }
}
