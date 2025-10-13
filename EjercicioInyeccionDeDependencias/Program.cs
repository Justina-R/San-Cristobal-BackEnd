using EjercicioInyeccionDeDependencias;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//---- Contenedor de dependencias ----
// Interfaz que implementa EmailService (se inyecta en UserService.cs)
builder.Services.AddTransient<IEmailService, EmailService>();

// Servicios del usuario (se inyecta en UserController.cs)
builder.Services.AddTransient<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
