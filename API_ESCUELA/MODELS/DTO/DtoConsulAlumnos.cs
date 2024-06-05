namespace API_ESCUELA.MODELS.DTO;

public record DtoConsulAlumnos
{
    public int Matricula { get; init; } = 0;
    public string Alumno { get; init; } = string.Empty;
    public string Estatus { get; init; } = string.Empty;
    public string FecNaci { get; init; } = string.Empty;

}
