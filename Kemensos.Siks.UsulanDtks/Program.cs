using Kemensos.Siks.UsulanDtks.Application.Commands.PkhListIndividu;
using Kemensos.Siks.UsulanDtks.Domain.Pkh;
using Kemensos.Siks.UsulanDtks.Infrastructure.Persistence.InMemory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IIndividuDataRepository, IndividuDataRepository>();
builder.Services.AddScoped<PkhListIndividuCommand>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

