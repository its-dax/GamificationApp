using GamificationApp.Server.Repositories;
using GamificationApp.Shared.DTOs;
using GamificationApp.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GamificationApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
       

        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthController(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginDto request)
        {
            try
            {
                var users = await _userRepository.GetUsers();

                if (users is null)
                {
                    return NotFound();
                }

                var currentUser = users.First(u => u.Code == request.Code && u.Password == request.Password);

                if (currentUser is null)
                {
                    return NotFound();
                }

                string token = CreateToken(currentUser);
                return Ok(token);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Hiba a bejelentkezésben.");
            }
            
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Code),
            };
            claims.Add(new Claim("Id", user.Id.ToString()));
            if(user.Role == 0)
            {
                claims.Add(new Claim(ClaimTypes.Role, "Student"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "Teacher"));

            }
            

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
