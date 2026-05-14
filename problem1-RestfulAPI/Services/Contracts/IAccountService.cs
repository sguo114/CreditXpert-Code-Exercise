using problem1_RestfulAPI.Models;

namespace problem1_RestfulAPI.Services.Contracts;

public interface IAccountService
{
    IEnumerable<CreditAccount> GetAll(int page, int pageSize);
    CreditAccount? GetById(int id);
    CreditAccount Create(CreditAccount account);
    bool Update(int id, CreditAccount account);
    bool Delete(int id);
}