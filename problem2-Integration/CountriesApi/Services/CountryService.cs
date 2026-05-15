using System.Text.Json;
using CountriesApi.Models;
using CountriesApi.Services.Abstractions;

namespace CountriesApi.Services;

public class CountryService : ICountryService
{
    private readonly HttpClient _httpClient;
    private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };

    public CountryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://restcountries.com/v3.1/");
    }

    public async Task<CountryStats> GetRegionStatsAsync(string region, string sortBy)
    {
        var response = await _httpClient.GetAsync("all?fields=name,population,region,flags");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();
        var allCountries = JsonSerializer.Deserialize<List<Country>>(content, JsonOptions) ?? [];
        
        var filteredCountries = FilterByRegion(allCountries, region).ToList();
        if (filteredCountries.Count == 0) 
            return new CountryStats { Region = region };
        
        var sortedSummaries = ApplySorting(filteredCountries, sortBy);

        return new CountryStats
        {
            Region = region.Equals("all", StringComparison.OrdinalIgnoreCase) ? "Global" : region,
            TotalPopulation = filteredCountries.Sum(c => c.Population),
            Countries = sortedSummaries.ToList()
        };
    }
    
    private static IEnumerable<Country> FilterByRegion(IEnumerable<Country> countries, string region)
    {
        Func<Country, bool> regionFilter = region.Equals("all", StringComparison.OrdinalIgnoreCase)
            ? _ => true
            : c => c.Region.Equals(region, StringComparison.OrdinalIgnoreCase);

        return countries.Where(regionFilter);
    }

    private static IEnumerable<Country> ApplySorting(IEnumerable<Country> countries, string sortBy)
    {
        return sortBy.ToLower() switch
        {
            "name" => countries.OrderBy(c => c.Name.Common),
            "name_desc" => countries.OrderByDescending(c => c.Name.Common),
            "population_asc" => countries.OrderBy(c => c.Population),
            _ => countries.OrderByDescending(c => c.Population)
        };
    }
}