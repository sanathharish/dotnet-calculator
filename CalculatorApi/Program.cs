using CalculatorApp.Interfaces;
using CalculatorApp.Services;
using CalculatorApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddScoped<ICalculator, Calculator>();
builder.Services.AddControllers();

// Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Global exception handling
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();

