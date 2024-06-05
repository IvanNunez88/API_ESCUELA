namespace API_ESCUELA.MODELS.DTO;

public record DtoAltaAlumno
{
    public string Nombre { get; init; } = string.Empty;
    public string APaterno { get; init; } = string.Empty;
    public string AMaterno { get; init; } = string.Empty;
    public string FecNaci { get; init; } = string.Empty;

}