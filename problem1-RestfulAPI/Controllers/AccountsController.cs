using Microsoft.AspNetCore.Mvc;
using problem1_RestfulAPI.Models;
using problem1_RestfulAPI.Services.Contracts;

namespace problem1_RestfulAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public IActionResult GetAccounts([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        return Ok(_accountService.GetAll(page, pageSize));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetAccount(int id)
    {
        var account = _accountService.GetById(id);
        return account == null ? NotFound() : Ok(account);
    }

    [HttpPost]
    public IActionResult CreateAccount([FromBody] CreditAccount account)
    {
        if (string.IsNullOrEmpty(account.OwnerName) || account.CreditLimit < 0)
            return BadRequest("Invalid account data.");

        var created = _accountService.Create(account);
        return CreatedAtAction(nameof(GetAccount), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAccount(int id, [FromBody] CreditAccount account)
    {
        if (id != account.Id)
            return BadRequest("ID mismatch between URL and request body.");

        var updated = _accountService.Update(id, account);
        if (!updated) return NotFound($"Account with ID {id} not found.");

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAccount(int id)
    {
        var deleted = _accountService.Delete(id);
        if (!deleted) return NotFound($"Account with ID {id} not found.");

        return NoContent();
    }
}