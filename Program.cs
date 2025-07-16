using CadastroTarefaAPI.DbContextGeneral;
using CadastroTarefaAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ITaskToDoRepository, TaskToDoRepository>();
builder.Services.AddDbContext<PrincipalDbContext>(options => options.UseInMemoryDatabase("BancoTeste"));
builder.Services.AddControllers();

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();
app.UseHttpsRedirection();

app.Run();