using CountriesApi.Models;

namespace CountriesApi.Services.Abstractions;

public interface ICountryService
{
    Task<CountryStats> GetRegionStatsAsync(string region, string sortBy);
}