using ChikovMF.Application.Features.Authorization.GetToken;
using ChikovMF.Application.Features.Authorization.SendCode;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ChikovMF.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetCode()
        {
            var query = new GetTokenQuery();
            await _mediator.Send(query);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(string token, [FromServices] IConfiguration config)
        {
            var command = new SendCodeCommand
            {
                Token = token
            };
            var isValid = await _mediator.Send(command);
            

            if (isValid)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtAuth:Key"]!));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: config["JwtAuth:Issuer"],
                    audience: config["JwtAuth:Issuer"],
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok( tokenString );
            }

            return Unauthorized();
        }

        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
