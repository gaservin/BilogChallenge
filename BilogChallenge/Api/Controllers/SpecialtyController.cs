using BilogChallenge.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace BilogChallenge.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtyController( ISpecialtyService specialtyService ) 
        {
            _specialtyService = specialtyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok( await _specialtyService.GetAllSpecialties() );
    }
}