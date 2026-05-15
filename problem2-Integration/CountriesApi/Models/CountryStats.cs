namespace CountriesApi.Models;

public class CountryStats
{
    public string Region { get; set; } = string.Empty;
    public long TotalPopulation { get; set; }
    public List<Country> Countries { get; set; } = [];
}