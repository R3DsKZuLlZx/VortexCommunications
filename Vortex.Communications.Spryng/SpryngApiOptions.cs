using System.ComponentModel.DataAnnotations;

namespace Vortex.Communications.Spryng;

public class SpryngApiOptions
{
    public SpryngApiOptions(string token)
    {
        Token = token;
    }
    
    public SpryngApiOptions(string token, string baseAddress)
    {
        Token = token;
        BaseAddress = new Uri(baseAddress);
    }
    
    public SpryngApiOptions(string token, Uri baseAddress)
    {
        Token = token;
        BaseAddress = baseAddress;
    }
    
    /// <summary>
    /// The base address used for the Spryng API.
    /// </summary>
    public Uri BaseAddress { get; init; } = new("https://rest.spryngsms.com");
        
    /// <summary>
    /// The bearer token used for the Spryng API.
    /// </summary>
    [Required]
    public string Token { get; init; }
}
