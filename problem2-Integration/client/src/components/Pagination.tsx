interface PaginationProps {
  currentPage: number;
  totalPages: number;
  loading: boolean;
  onPageChange: (page: number | ((prev: number) => number)) => void;
}

export function Pagination({ currentPage, totalPages, loading, onPageChange }: PaginationProps) {
  if (totalPages <= 1) return null;

  return (
    <nav className="pagination-wrapper" aria-label="Country grid pagination">
      <button
        className="pag-btn"
        onClick={() => onPageChange((prev) => Math.max(prev - 1, 1))}
        disabled={currentPage === 1 || loading}
      >
        Previous
      </button>
      <span className="pag-indicator">
        Page <strong>{currentPage}</strong> of {totalPages}
      </span>
      <button
        className="pag-btn"
        onClick={() => onPageChange((prev) => Math.min(prev + 1, totalPages))}
        disabled={currentPage === totalPages || loading}
      >
        Next
      </button>
    </nav>
  );
}
