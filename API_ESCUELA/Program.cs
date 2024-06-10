//using API_ESCUELA.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var MisReglasCors = "ReglasCors";

builder.Services.AddCors(option =>
    option.AddPolicy(name: MisReglasCors,
    builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    }));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSingleton<DapperContext>;

var app = builder.Build();

//IMPORTACIÓN DE ARCHIVO JSON AL PROYECTO
builder.Configuration.AddJsonFile("appsettings.json");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//HABILITAR EL USO DE LOS CORS
app.UseCors(MisReglasCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
