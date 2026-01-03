using CalculatorApp.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers;

[ApiController]
[Route("api/calculator")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculator _calculator;

    public CalculatorController(ICalculator calculator)
    {
        _calculator = calculator;
    }

    [HttpGet("add")]
    public IActionResult Add(int a, int b)
    {
        return Ok(_calculator.Add(a, b));
    }
}
