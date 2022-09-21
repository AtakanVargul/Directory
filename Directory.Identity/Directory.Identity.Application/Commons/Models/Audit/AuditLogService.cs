using Directory.Identity.Application.Commons.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Directory.Identity.Application.Commons.Models.Audit;

public class AuditLogService : IAuditLogService
{
    private readonly IBus _bus;
    private readonly ILogger<AuditLogService> _logger;

    public AuditLogService(IBus bus,
                           ILogger<AuditLogService> logger)
    {
        _bus = bus;
        _logger = logger;
    }
    public async Task AuditLogAsync(AuditLog auditLog)
    {
        try
        {
            var tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));
            var endpoint = await _bus.GetSendEndpoint(new Uri("exchange:Log.AuditLog"));
            await endpoint.Send(auditLog, tokenSource.Token);
        }
        catch (Exception exception)
        {
            _logger.LogError($"ExceptionOnSendAuditLog detail:\n{exception}");
        }
    }
}
