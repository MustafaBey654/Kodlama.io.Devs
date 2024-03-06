
using Core.Security.Dtos;
using Core.Security.Entities;
using Course.Application.Features.Auth.Command.Register;
using Course.Application.Features.Auth.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Course.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("Register")]

        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterCommand registerCommand = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress()
            };

            RegisteredDto result = await Mediator.Send(registerCommand);

            SetRefReshTokenToCookie(result.RefreshToken);
            return Created("", result.AccessToken);
        }

        private void SetRefReshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new CookieOptions() { HttpOnly = true, Expires = DateTime.Now.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }


          
          
    }
}
