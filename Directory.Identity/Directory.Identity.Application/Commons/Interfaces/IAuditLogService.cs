using Directory.Identity.Application.Commons.Models.Audit;

namespace Directory.Identity.Application.Commons.Interfaces;

public interface IAuditLogService
{
    public Task AuditLogAsync(AuditLog auditLog);
}
