using SarjCost.Enum;


namespace SarjCost.Data.Entity;

public class ExternalLogin
{
    public Guid Id { get; set; }

    public AuthProvider Provider { get; set; } // "Google", "Facebook", "Apple", etc.

    public string ProviderUserId { get; set; } // Unique ID from the provider

    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

    public DateTime ExpiresAt { get; set; }

    public Guid UserId { get; set; }

    public User User { get; set; }
}
