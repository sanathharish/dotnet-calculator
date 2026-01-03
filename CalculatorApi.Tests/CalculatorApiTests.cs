using System.Net;
using System.Net.Http.Json;
using CalculatorApi.DTOs;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class CalculatorApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CalculatorApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Add_ReturnsCorrectResult()
    {
        var request = new CalculationRequest { A = 5, B = 7 };

        var response = await _client.PostAsJsonAsync("/api/v1/calculator/add", request);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        Assert.Equal("12", result);
    }


    [Fact]
    public async Task Divide_ByZero_ReturnsBadRequest()
    {
        var request = new CalculationRequest { A = 10, B = 0 };

        var response = await _client.PostAsJsonAsync("/api/v1/calculator/divide", request);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}
