using CalculatorApi.DTOs;
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

    [HttpPost("add")]
    public IActionResult Add([FromBody] CalculationRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(_calculator.Add(request.A, request.B));
    }

    [HttpPost("subtract")]
    public IActionResult Subtract([FromBody] CalculationRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(_calculator.Subtract(request.A, request.B));
    }

    [HttpPost("multiply")]
    public IActionResult Multiply([FromBody] CalculationRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(_calculator.Multiply(request.A, request.B));
    }

    [HttpPost("divide")]
    public IActionResult Divide([FromBody] CalculationRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            return Ok(_calculator.Divide(request.A, request.B));
        }
        catch (DivideByZeroException)
        {
            return BadRequest("Cannot divide by zero.");
        }
    }
}
