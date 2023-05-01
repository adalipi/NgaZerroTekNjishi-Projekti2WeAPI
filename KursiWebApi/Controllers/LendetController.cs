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
    }
}
