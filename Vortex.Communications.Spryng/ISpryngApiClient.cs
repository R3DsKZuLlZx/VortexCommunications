using Vortex.Communications.Spryng.Models;

namespace Vortex.Communications.Spryng;

public interface ISpryngApiClient
{
    /// <summary>
    /// Sends an sms message using Spryng.
    /// </summary>
    /// <param name="sendSmsRequest">Request used to create the sms message.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The Spryng response with the sms message data.</returns>
    Task<SendSmsResponse> SendSms(
        SendSmsRequest sendSmsRequest,
        CancellationToken cancellationToken);
}
