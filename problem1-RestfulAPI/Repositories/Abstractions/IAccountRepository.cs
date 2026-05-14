using problem1_RestfulAPI.Models;

namespace problem1_RestfulAPI.Repositories.Abstractions;

public interface IAccountRepository {
    IEnumerable<CreditAccount> GetAll();
    CreditAccount? GetById(int id);
    void Add(CreditAccount account);
    bool Update(CreditAccount account);
    bool Delete(int id);
}