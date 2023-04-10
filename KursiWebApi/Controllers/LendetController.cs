using KursiDatabase.Models;
using KursiDatabase.Repository;
using KursiWebApi.DTOs;
using KursiWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KursiWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LendetController : ControllerBase
    {
        private readonly ILogger<LendetController> _logger;
        private readonly IRepository<Lendet> _repository;
        private readonly ILendetService _lendetService;
        private readonly IConfiguration _configuration;

        public LendetController(ILogger<LendetController> logger, IRepository<Lendet> repository, ILendetService lendetService, IConfiguration configuration)
        {
            _logger = logger;
            _repository = repository;
            _lendetService = lendetService;
            _configuration = configuration;
        }

        [HttpGet("[action]")]
        public TestKlas GetTest()
        {
            _logger.LogInformation("testi i pare");
            _logger.LogDebug("testi i pare Debug");

            var obj = new TestKlas();
            obj.mosha= 19;
            obj.emri = "Filan";

            return obj;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<Lendet> MerrLenden(int id, CancellationToken token)//spjego cancelation token
        {
            return await _repository.Get(id, token);//spjego async await
        }
        
        
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<Lendet> MerrLendenDheStudentet(int id, CancellationToken token)//spjego cancelation token
        {
            return await _repository.GetAll().Include(f => f.Klasa).Include(f => f.Studentet).FirstOrDefaultAsync(lenda => lenda.Id == id, token);//spjego async await
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Regjistro(LendaDto lenda, CancellationToken token)
        {
            await _lendetService.RegjistroLenden(lenda, token);
            _logger.LogInformation($"Regjistruam klasen me emrin: {lenda.Emri}.");
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public string Login(AuthRequestObject authObj, CancellationToken cancellationtoken)
        {
            if(authObj.Username == "ari" && authObj.Password == "dalipi") 
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

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            return "";
        }

    }
}
