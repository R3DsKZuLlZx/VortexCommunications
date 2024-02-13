using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vortex.Communications.Spryng.Models;

namespace Vortex.Communications.Spryng;

public class SpryngApiClient : ISpryngApiClient
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        PropertyNameCaseInsensitive = true,
    };

    private readonly HttpClient _client;
    private readonly SpryngApiOptions _options;

    public SpryngApiClient(HttpClient client, SpryngApiOptions options)
    {
        _client = client;
        _options = options;
    }
    
    public async Task<SendSmsResponse> SendSms(SendSmsRequest sendSmsRequest, CancellationToken cancellationToken)
    {
        if (sendSmsRequest.ScheduledAt.HasValue)
        {
            sendSmsRequest.ScheduledAt =
                sendSmsRequest.ScheduledAt.Value.AddTicks(-(sendSmsRequest.ScheduledAt.Value.Ticks % TimeSpan.TicksPerSecond));
        }
        
        var content = JsonSerializer.Serialize(sendSmsRequest, JsonSerializerOptions);
        var request = new HttpRequestMessage
        {
            RequestUri = new Uri(_options.BaseAddress, "/v1/messages"),
            Method = HttpMethod.Post,
            Headers =
            {
                { "Authorization", $"Bearer {_options.Token}" },
            },
            Content = new StringContent(content, Encoding.UTF8, "application/json"),
        };
        
        var response = await _client.SendAsync(request, cancellationToken);
        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        
        return JsonSerializer.Deserialize<SendSmsResponse>(json, JsonSerializerOptions)!;
    }
}
