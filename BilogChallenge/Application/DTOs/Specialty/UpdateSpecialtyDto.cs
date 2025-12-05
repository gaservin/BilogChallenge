namespace BilogChallenge.Application.DTOs.Specialty
{
    public record UpdateSpecialtyDto( string cod_especialidad, string descripcion, byte[] rowversion );
}