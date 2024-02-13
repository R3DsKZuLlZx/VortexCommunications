namespace Vortex.Communications.Spryng.Models;

public class SendSmsRequest
{
    public required string Body { get; set; }
    public required List<string> Recipients { get; set; }
    public required string Originator { get; set; }
    public string Encoding { get; set; } = "auto";
    public string Route { get; set; } = "business";
    public DateTimeOffset? ScheduledAt { get; set; }
    public string? Reference { get; set; }
}
