using System.Text.Json.Serialization;

namespace Vortex.Communications.Spryng.Models;

public class SendSmsResponse
{
    public Guid Id { get; set; }
    public string? Encoding { get; set; }
    public string? Originator { get; set; }
    public string? Body { get; set; }
    public string? Reference { get; set; }
    public decimal? Credits { get; set; }
    public DateTimeOffset? ScheduledAt { get; set; }
    public DateTimeOffset? CanceledAt { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public object? Links { get; set; }

    [JsonPropertyName("message")]
    public string? ErrorMessage { get; set; }
    public object? Errors { get; set; }
}
