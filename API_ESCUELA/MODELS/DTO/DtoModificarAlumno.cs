namespace API_ESCUELA.MODELS.DTO
{
     public record DtoModificarAlumno
    {
        public int Matricula { get; set; }
        public string Nombre { get; init; } = string.Empty;
        public string APaterno { get; init; } = string.Empty;
        public string AMaterno { get; init; } = string.Empty;
        public string FecNaci { get; init; } = string.Empty;
        public bool Estatus { get; set; } = false;

    }
}
