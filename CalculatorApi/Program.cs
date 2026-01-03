using CalculatorApp.Interfaces;
using CalculatorApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Register core logic
builder.Services.AddScoped<ICalculator, Calculator>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
