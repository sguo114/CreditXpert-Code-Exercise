using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace problem1_RestfulAPI.Models;

public class CreditAccount
{
    public int Id { get; set; }
    
    [Required]
    public string OwnerName { get; set; } = string.Empty;

    public decimal CreditLimit { get; set; }
    public decimal CurrentBalance { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public AccountStatus AccountStatus { get; set; } = AccountStatus.Active;
}