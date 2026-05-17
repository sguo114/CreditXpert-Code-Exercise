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

    public CreditAccount Create(CreateAccountDto dto)
    {
        var allAccounts = _accountRepository.GetAll().ToList();
        var id = allAccounts.Count != 0 ? allAccounts.Max(a => a.Id) + 1 : 1;
        
        var account = new CreditAccount
        {
            Id = id,
            OwnerName = dto.OwnerName,
            CreditLimit = dto.CreditLimit,
            CurrentBalance = 0,
            AccountStatus = AccountStatus.Active
        };
        
        _accountRepository.Add(account);
        return account;
    }

    public bool Update(int id, UpdateAccountDto accountUpdates)
    {
        var updatedAccount = new CreditAccount
        {
            Id = id,
            OwnerName = accountUpdates.OwnerName,
            CreditLimit = accountUpdates.CreditLimit,
            CurrentBalance = accountUpdates.CurrentBalance,
            AccountStatus = accountUpdates.AccountStatus
        };
        return _accountRepository.Update(updatedAccount);
    }

    public bool Delete(int id) => _accountRepository.Delete(id);
}