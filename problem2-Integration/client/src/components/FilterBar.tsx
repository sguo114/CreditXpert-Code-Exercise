interface FilterBarProps {
  region: string;
  sortBy: string;
  loading: boolean;
  onRegionChange: (region: string) => void;
  onSortChange: (sort: string) => void;
}

const REGIONS = [
  { value: "all", label: "Global / All Regions" },
  { value: "africa", label: "Africa" },
  { value: "americas", label: "Americas" },
  { value: "antarctic", label: "Antartic" },
  { value: "asia", label: "Asia" },
  { value: "europe", label: "Europe" },
  { value: "oceania", label: "Oceania" },
];

const SORT_OPTIONS = [
  { value: "population_desc", label: "Highest Population First" },
  { value: "population_asc", label: "Lowest Population First" },
  { value: "name", label: "Alphabetical (A - Z)" },
  { value: "name_desc", label: "Alphabetical (Z - A)" },
];

export function FilterBar({ region, sortBy, loading, onRegionChange, onSortChange }: FilterBarProps) {
  return (
    <section className="filter-bar">
      <div className="control-group">
        <label htmlFor="region-select">Filter by Geographic Region</label>
        <select id="region-select" value={region} onChange={(e) => onRegionChange(e.target.value)} disabled={loading}>
          {REGIONS.map((option) => (
            <option key={option.value} value={option.value}>
              {option.label}
            </option>
          ))}
        </select>
      </div>

      <div className="control-group">
        <label htmlFor="sort-select">Sort Metrics</label>
        <select id="sort-select" value={sortBy} onChange={(e) => onSortChange(e.target.value)} disabled={loading}>
          {SORT_OPTIONS.map((option) => (
            <option key={option.value} value={option.value}>
              {option.label}
            </option>
          ))}
        </select>
      </div>
    </section>
  );
}
