using problem1_RestfulAPI.Models;
using problem1_RestfulAPI.Repositories.Abstractions;

namespace problem1_RestfulAPI.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly List<CreditAccount> _accounts = [
        new() { Id = 1, OwnerName = "Frodo Baggins", CreditLimit = 5000, CurrentBalance = 1200, AccountStatus = AccountStatus.Active },
        new() { Id = 2, OwnerName = "Samwise Gamgee", CreditLimit = 3000, CurrentBalance = 0, AccountStatus = AccountStatus.Active },
        new() { Id = 3, OwnerName = "Gandalf The Grey", CreditLimit = 3000, CurrentBalance = 0, AccountStatus = AccountStatus.Closed },
        new() { Id = 4, OwnerName = "Saruman The White", CreditLimit = 10000, CurrentBalance = 9500, AccountStatus = AccountStatus.Delinquent }
    ];

    public IEnumerable<CreditAccount> GetAll() => _accounts;

    public CreditAccount? GetById(int id) => _accounts.FirstOrDefault(a => a.Id == id);

    public void Add(CreditAccount account) => _accounts.Add(account);

    public bool Update(CreditAccount updatedAccount)
    {
        var existing = GetById(updatedAccount.Id);
        if (existing == null) return false;

        existing.OwnerName = updatedAccount.OwnerName;
        existing.CreditLimit = updatedAccount.CreditLimit;
        existing.CurrentBalance = updatedAccount.CurrentBalance;
        existing.AccountStatus = updatedAccount.AccountStatus;
        return true;
    }

    public bool Delete(int id) => _accounts.RemoveAll(a => a.Id == id) > 0;
}