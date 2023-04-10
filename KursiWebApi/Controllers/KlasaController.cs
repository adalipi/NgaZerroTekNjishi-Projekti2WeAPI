using KursiDatabase.Models;
using KursiDatabase.Repository;
using KursiWebApi.DTOs;
using KursiWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KursiWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlasaController : ControllerBase
    {
        private readonly ILogger<KlasaController> _logger;
        private readonly IKlasaService _service;

        public KlasaController(ILogger<KlasaController> logger, IKlasaService service)
        {
            _logger = logger;
            _service = service;
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Regjistro(KlasaDto klasa, CancellationToken token)
        {
            await _service.RegisterKlasa(klasa, token);
            _logger.LogInformation($"Regjistruam klasen me emrin: {klasa.Emri}.");
            return Ok();
        }


    }
}
