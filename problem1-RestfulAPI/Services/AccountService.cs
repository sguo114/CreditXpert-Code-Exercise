using problem1_RestfulAPI.Models;
using problem1_RestfulAPI.Repositories.Abstractions;
using problem1_RestfulAPI.Services.Contracts;

namespace problem1_RestfulAPI.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository) 
    {
        _accountRepository = accountRepository;
    }

    public IEnumerable<CreditAccount> GetAll(int page, int pageSize) =>
        _accountRepository.GetAll().Skip((page - 1) * pageSize).Take(pageSize);

    public CreditAccount? GetById(int id) => _accountRepository.GetById(id);

    public CreditAccount Create(CreditAccount account)
    {
        var allAccounts = _accountRepository.GetAll().ToList();
        account.Id = allAccounts.Count != 0 ? allAccounts.Max(a => a.Id) + 1 : 1;
        
        _accountRepository.Add(account);
        return account;
    }

    public bool Update(int id, CreditAccount updatedAccount)
    {
        updatedAccount.Id = id;
        return _accountRepository.Update(updatedAccount);
    }

    public bool Delete(int id) => _accountRepository.Delete(id);
}