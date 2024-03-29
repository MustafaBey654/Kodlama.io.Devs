
using Course.Persistence;
using Course.Application;
using Core.CrossCuttingConcerns.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplicationServices();
//builder.Services.AddSecurityServices();
builder.Services.AddPersistenceServices(builder.Configuration);
//builder.Services.AddInfrastructureServices();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
