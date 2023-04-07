using KursiDatabase.Models;
using KursiDatabase.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KursiWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendetController : ControllerBase
    {
        private readonly ILogger<LendetController> _logger;
        private readonly IRepository<Lendet> _repository;

        public LendetController(ILogger<LendetController> logger, IRepository<Lendet> repository)
        {
            _logger = logger;
            _repository = repository;
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

    }
}
