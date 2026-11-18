using PC28168.U20241G031.OpenPay.Platform.Shared.Domain.Repositories;
using PC28168.U20241G031.Openpay.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using PC28168.U20241G031.OpenPay.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace PC28168.U20241G031.OpenPay.Platform.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Entity Framework Core Unit of Work implementation.
/// </summary>
/// <param name="context">The database context.</param>
/// <remarks>Piero Francisco Montes Chang</remarks>
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}