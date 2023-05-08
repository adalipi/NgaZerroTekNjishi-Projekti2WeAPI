using KursiWebApi.DTOs;
using KursiWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KursiWebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentiController : ControllerBase
    {
        private readonly IStudentiService _studentService;

        public StudentiController(IStudentiService studentService) 
        { 
            _studentService= studentService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Regjistro(StudentiDto student, CancellationToken token)
        {
            await _studentService.RegjistroStudentin(student, token);
            return Ok();
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> MerrStudentet(CancellationToken token)
        {
            return Ok(await _studentService.GjitheStudentet(token));
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> MerrStudentetAuth(CancellationToken token)
        {
            return Ok(await _studentService.GjitheStudentet(token));
        }

        //[HttpGet]
        //[Route("[action]")]
        //public async Task<IActionResult> MTake()
        //{
        //    return Ok(BCrypt.Net.BCrypt.HashPassword("test123"));
        //}
    }
}
