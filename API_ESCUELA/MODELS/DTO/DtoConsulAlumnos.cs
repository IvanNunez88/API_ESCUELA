namespace API_ESCUELA.MODELS.DTO;

public record DtoConsulAlumnos
{
    public int Matricula { get; init; } = 0;
    public string Alumno { get; init; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public string APaterno { get; set; } = string.Empty;
    public string AMaterno { get; set; } = string.Empty;
    public string Estatus { get; init; } = string.Empty;
    public string FecNaci { get; init; } = string.Empty;
    public string FecNaciF { get; init; } = string.Empty;
    public bool IdEstatus { get; init; } = false;
}
