import { useState, useTransition } from "react";
import { useCountryStats } from "./hooks/useCountryStats";
import { MetricRibbon } from "./components/MetricRibbon";
import { FilterBar } from "./components/FilterBar";
import { CountryGrid } from "./components/CountryGrid";
import { Pagination } from "./components/Pagination";

const ITEMS_PER_PAGE = 12;

export default function App() {
  const { region, setRegion, sortBy, setSortBy, data, loading, error } = useCountryStats();
  const [currentPage, setCurrentPage] = useState(1);
  const [, startTransition] = useTransition();

  const countries = data?.countries || [];
  const totalPages = Math.ceil(countries.length / ITEMS_PER_PAGE);
  const startIndex = (currentPage - 1) * ITEMS_PER_PAGE;
  const paginatedCountries = countries.slice(startIndex, startIndex + ITEMS_PER_PAGE);

  return (
    <main className="container">
      <header className="app-header">
        <h1>Countries Stats Dashboard</h1>
        <p className="subtitle">Dashboard to show Country Populations, Flags, and Regions</p>
      </header>

      <MetricRibbon
        region={data?.region || "Global"}
        totalPopulation={data?.totalPopulation || 0}
        count={countries.length}
        loading={loading}
      />

      <FilterBar
        region={region}
        sortBy={sortBy}
        loading={loading}
        onRegionChange={(r) =>
          startTransition(() => {
            setRegion(r);
            setCurrentPage(1);
          })
        }
        onSortChange={(s) =>
          startTransition(() => {
            setSortBy(s);
            setCurrentPage(1);
          })
        }
      />

      <CountryGrid countries={paginatedCountries} loading={loading} error={error} />

      <Pagination currentPage={currentPage} totalPages={totalPages} loading={loading} onPageChange={setCurrentPage} />
    </main>
  );
}
