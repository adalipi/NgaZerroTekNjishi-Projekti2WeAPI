using KursiDatabase.Repository;
using KursiWebApi.DTOs;
using KursiWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace KursiWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IStudentiService _studentService;

        public AuthController(IConfiguration configuration, IStudentiService studentService)
        {
            _configuration = configuration;
            _studentService = studentService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login(AuthRequestObject authObj, CancellationToken cancellationtoken)
        {
            var obj = await _studentService.GjejStudentinPermesEmailit(authObj.Username, cancellationtoken);
            if (obj != null && BCrypt.Net.BCrypt.Verify(authObj.Password, obj.Fjalkalimi))
            {
                if (!int.TryParse(_configuration["Jwt:Expiration"], out int exp))
                    exp = 20;

                var expiry = DateTime.Now.AddMinutes(int.Parse(_configuration["Jwt:Expiration"]));
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Issuer"],
                    null,
                    expires: expiry,
                    signingCredentials: signIn);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }

            return BadRequest();
        }
    }
}
