using CountriesApi.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CountriesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountriesController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpGet("stats")]
    public async Task<IActionResult> GetStats([FromQuery] string region = "all", [FromQuery] string sortBy = "name")
    {
        try 
        {
            var result = await _countryService.GetRegionStatsAsync(region, sortBy);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(503, new { message = "Data source unavailable", error = ex.Message });
        }
    }
}