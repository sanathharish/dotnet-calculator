using CalculatorApp.Services;
using Xunit;

namespace CalculatorApp.Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Calculator();
    }

    [Fact]
    public void Add_ShouldReturnCorrectSum()
    {
        // Act
        int result = _calculator.Add(5, 7);

        // Assert
        Assert.Equal(12, result);
    }
}
