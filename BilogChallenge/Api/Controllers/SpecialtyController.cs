using BilogChallenge.Application.DTOs.Specialty;
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
        [ProducesResponseType(typeof(IReadOnlyList<SpecialtyDto>), 200)]
        public async Task<IActionResult> Get() => Ok( await _specialtyService.GetAllSpecialtiesAsync() );

        [HttpGet("{id}")]
        public async Task<IActionResult> Get( int id )
        {
            var specialty = await _specialtyService.GetByIdSpecialtyAsync( id );
            if ( specialty == null ) return NotFound( $"Especialidad con ID {id} no encontrada." );
            return Ok( specialty );
        }

        [HttpPost]
        public async Task<IActionResult> Create( [FromBody] CreateSpecialtyDto newSpecialty )
        {
            try
            {
                var createdSpecialty = await _specialtyService.AddSpecialtyAsync( newSpecialty );
                return CreatedAtAction( nameof( Get ), new { id = createdSpecialty.id_especialidad }, createdSpecialty );
            }
            catch ( Exception ex )
            {
                return Conflict( new { message = ex.Message } );
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update( int id, [FromBody] UpdateSpecialtyDto updateSpecialty )
        {
            try
            {
                var updatedSpecialty = await _specialtyService.UpdateSpecialtyAsync( id, updateSpecialty );

                if ( updatedSpecialty == null ) return NotFound( $"Especialidad con ID {id} no encontrada." );

                return Ok( updatedSpecialty );
            }
            catch ( Exception ex )
            {
                return Conflict( ex.Message );
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var specialty = await _specialtyService.GetByIdSpecialtyAsync( id );
                if ( specialty == null ) return NotFound( $"Especialidad con ID {id} no encontrada." );

                await _specialtyService.DeleteSpecialtyAsync( id );

                return Ok( new { message = $"Especialidad con ID {id} eliminada correctamente." } );
            }
            catch ( Exception ex )
            {
                return Conflict( ex.Message );
            }
        }
    }
}