namespace ChikovMF.Entities;

public class AccessToken
{
    public Guid AccessTokenId { get; set; }
    public DateTime DateOfReceiving { get; set; }
    public string HashToken { get; set; } = null!;
}
