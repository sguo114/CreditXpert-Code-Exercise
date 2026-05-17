using System.Text.Json.Serialization;
using problem1_RestfulAPI.Models;

namespace problem1_RestfulAPI.Services.Contracts;

public class UpdateAccountDto
{
    public string OwnerName { get; set; } = string.Empty;
    public decimal CreditLimit { get; set; }
    public decimal CurrentBalance { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AccountStatus AccountStatus { get; set; } = AccountStatus.Active;
}