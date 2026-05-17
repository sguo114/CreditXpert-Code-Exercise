import type { CountryStats } from "../types/countries";

const BASE_URL = import.meta.env.VITE_API_URL || "http://localhost:8080/api";

export const CountryApiService = {
  /**
   * @param region The target region (e.g., 'all', 'europe', 'americas')
   * @param sortBy The sorting rule (e.g., 'population_desc', 'name')
   */
  async getStats(region: string, sortBy: string): Promise<CountryStats> {
    const url = `${BASE_URL}/countries/stats?region=${encodeURIComponent(region)}&sortBy=${encodeURIComponent(sortBy)}`;

    const response = await fetch(url, {
      method: "GET",
      headers: {
        "Accept": "application/json",
      },
    });

    if (!response.ok) {
      let errorMessage = "An error occurred while fetching data from the server.";
      try {
        const errorData = await response.json();
        errorMessage = errorData.message || errorMessage;
      } catch {
        const rawText = await response.text();
        console.error(`[API Non-JSON Error Response Structure] Status: ${response.status}. Payload:`, rawText);

        if (response.status === 503) {
          errorMessage = "The data service is currently unavailable.";
        }
      }
      throw new Error(errorMessage);
    }

    return response.json();
  },
};
