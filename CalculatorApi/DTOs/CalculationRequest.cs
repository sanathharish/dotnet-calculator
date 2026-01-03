using System.ComponentModel.DataAnnotations;

namespace CalculatorApi.DTOs;

public class CalculationRequest
{
    [Required]
    public int A { get; set; }

    [Required]
    public int B { get; set; }
}
