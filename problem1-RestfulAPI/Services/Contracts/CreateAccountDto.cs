namespace problem1_RestfulAPI.Services.Contracts;

public class CreateAccountDto
{
    public string OwnerName { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
}