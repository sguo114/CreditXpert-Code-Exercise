export interface FlagInfo {
  png: string;
  alt: string;
}

export interface NameInfo {
  common: string;
  official: string;
}

export interface Country {
  name: NameInfo;
  population: number;
  region: string;
  flags: FlagInfo;
}

export interface CountryStats {
  region: string;
  totalPopulation: number;
  countries: Country[];
}
