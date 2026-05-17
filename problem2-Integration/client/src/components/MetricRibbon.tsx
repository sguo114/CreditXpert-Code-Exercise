interface MetricRibbonProps {
  region: string;
  totalPopulation: number;
  count: number;
  loading: boolean;
}

export function MetricRibbon({ region, totalPopulation, count, loading }: MetricRibbonProps) {
  return (
    <section className="metrics-ribbon">
      <div className="metric-card">
        <span className="metric-label">Active Region</span>
        <h2 className="metric-value">{region.toUpperCase() || (loading ? "Loading..." : "None")}</h2>
      </div>
      <div className="metric-card">
        <span className="metric-label">Total Population</span>
        <h2 className="metric-value">
          {loading && !totalPopulation ? "Computing..." : totalPopulation.toLocaleString()}
        </h2>
      </div>
      <div className="metric-card">
        <span className="metric-label">Country Count</span>
        <h2 className="metric-value">{loading && !count ? "Counting..." : `${count} Nations`}</h2>
      </div>
    </section>
  );
}
