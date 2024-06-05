namespace API_ESCUELA.MODELS;

public record ResponseApi<T>
{
    public string Status { get; set; }
    public T Value { get; set; }
    public string Msg { get; set; }
}
