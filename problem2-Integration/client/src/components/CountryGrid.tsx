import type { Country } from "../types/countries";

interface CountryGridProps {
  countries: Country[];
  loading: boolean;
  error: string | null;
}

export function CountryGrid({ countries, loading, error }: CountryGridProps) {
  if (error) {
    return (
      <div className="error-alert" role="alert">
        <h3>Error Retrieving Data</h3>
        <p>{error}</p>
      </div>
    );
  }

  if (loading && countries.length === 0) {
    return (
      <section className="country-grid">
        {[1, 2, 3, 4].map((i) => (
          <div key={i} className="country-card" style={{ border: "none" }}>
            <div className="skeleton skeleton-card-flag"></div>
            <div className="card-content">
              <div className="skeleton skeleton-text" style={{ marginBottom: "0.5rem", width: "70%" }}></div>
              <div className="skeleton skeleton-text" style={{ width: "40%" }}></div>
            </div>
          </div>
        ))}
      </section>
    );
  }

  if (!loading && countries.length === 0) {
    return (
      <div className="empty-state">
        <p>No geographic data matches the current filter parameters.</p>
      </div>
    );
  }

  return (
    <section className="country-grid" style={{ opacity: loading ? 0.6 : 1, transition: "opacity 0.15s ease" }}>
      {countries.map((country) => (
        <article key={country.name.official} className="country-card">
          <div className="flag-wrapper">
            <img
              src={country.flags.png}
              alt={country.flags.alt || `National flag of ${country.name.common}`}
              loading="lazy"
            />
          </div>
          <div className="card-content">
            <h3 className="country-title">{country.name.common}</h3>
            <p className="official-name" title={country.name.official}>
              {country.name.official}
            </p>
            <hr className="divider" />
            <div className="card-meta">
              <span className="meta-label">Population</span>
              <span className="meta-value">{country.population.toLocaleString()}</span>
            </div>
          </div>
        </article>
      ))}
    </section>
  );
}
