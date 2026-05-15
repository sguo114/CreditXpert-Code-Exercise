namespace CountriesApi.Models;

public class Country
{
    public NameInfo Name { get; set; } = new();
    public long Population { get; set; }
    public string Region { get; set; } = string.Empty;
    public FlagInfo Flags { get; set; } =  new();
}

public class NameInfo
{
    public string Common { get; set; } = string.Empty;
    public string Official { get; set; } = string.Empty;
}

public class FlagInfo
{
    public string Png { get; set; } = string.Empty;
    public string Alt { get; set; } = string.Empty;
}