using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Arch.Cqrs.Client.Auth;
using Arch.CrossCutting.CqrsContracts;
using Arch.Domain.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Arch.Ui.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IProcessor _processor;
        private readonly IConfiguration _config;

        public AuthController(
            IProcessor processor,
            IConfiguration config
            )
        {
            _processor = processor;
            _config = config;
        }
        [HttpPost("login")]
        public IActionResult Login(Login userLogin)
        {
            var user = _processor.Send<Login, User>(userLogin);
            
            if (user == null)
                return Unauthorized();
            
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {token = tokenHandler.WriteToken(token)});
        }
        [HttpPost("register")]
        public IActionResult Register(Register user)
        {
            var username = user.Username.ToLower();
            if(_processor.Get(new UserExists(username)))
            {
                var error = new { errors = new [] {"Username already exists"}};
                return BadRequest(error);
            }
            
            _processor.Send(user);
            return StatusCode(201);
        }
    }
}