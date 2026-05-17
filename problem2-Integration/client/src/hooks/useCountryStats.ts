import { useState, useEffect } from "react";
import type { CountryStats } from "../types/countries";
import { CountryApiService } from "../services/api";

export function useCountryStats(initialRegion = "all", initialSort = "population_desc") {
  const [region, setRegion] = useState(initialRegion);
  const [sortBy, setSortBy] = useState(initialSort);
  const [data, setData] = useState<CountryStats | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    let isMounted = true;

    async function fetchData() {
      setLoading(true);
      setError(null);
      try {
        const stats = await CountryApiService.getStats(region, sortBy);
        if (isMounted) {
          setData(stats);
        }
      } catch (err) {
        if (isMounted) {
          setError(err instanceof Error ? err.message : "An unexpected network error occurred.");
        }
      } finally {
        if (isMounted) {
          setLoading(false);
        }
      }
    }

    fetchData();

    return () => {
      isMounted = false;
    };
  }, [region, sortBy]);

  return { region, setRegion, sortBy, setSortBy, data, loading, error };
}
