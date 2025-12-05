using BilogChallenge.Application.DTOs.Specialty;
using BilogChallenge.Application.Exceptions;
using BilogChallenge.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public async Task<IActionResult> Get() => Ok( await _specialtyService.GetAllSpecialtiesAsync() );

        [HttpPost]
        public async Task<IActionResult> Create( [FromBody] CreateSpecialtyDto newSpecialty )
        {
            try
            {
                var createdSpecialty = await _specialtyService.AddSpecialtyAsync( newSpecialty );
                return CreatedAtAction( nameof( Get ), new { id = createdSpecialty.id_especialidad }, createdSpecialty );
            }
            catch ( DuplicateException ex )
            {
                return Conflict( new { message = ex.Message } );
            }
            catch ( ValidationException ex )
            {
                return BadRequest( new { message = ex.Message } );
            }
            catch ( Exception ex )
            {
                return StatusCode( 500, new { message = ex.Message } );
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update( int id, [FromBody] UpdateSpecialtyDto updateSpecialty )
        {
            try
            {
                var updatedSpecialty = await _specialtyService.UpdateSpecialtyAsync( id, updateSpecialty );
                return Ok( updatedSpecialty );
            }
            catch ( NotFoundException ex )
            {
                return NotFound( new { message = ex.Message } );
            }
            catch ( DuplicateException ex )
            {
                return Conflict( new { message = ex.Message } );
            }
            catch ( ConcurrencyException ex )
            {
                return Conflict( new { message = ex.Message } );
            }
            catch ( ValidationException ex )
            {
                return BadRequest( new { message = ex.Message } );
            }
            catch ( Exception ex )
            {
                return StatusCode( 500, new { message = ex.Message } );
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete( int id )
        {
            try
            {
                await _specialtyService.DeleteSpecialtyAsync( id );
                return Ok( new { message = $"Especialidad con ID {id} eliminada correctamente." } );
            }
            catch ( NotFoundException ex )
            {
                return NotFound( new { message = ex.Message } );
            }
            catch ( Exception ex )
            {
                return StatusCode( 500, new { message = ex.Message } );
            }
        }
    }
}