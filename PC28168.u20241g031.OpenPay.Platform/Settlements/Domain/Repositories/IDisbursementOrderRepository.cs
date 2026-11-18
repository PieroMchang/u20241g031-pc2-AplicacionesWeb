using PC28168.U20241G031.Openpay.Platform.Settlements.Domain.Model.Aggregates;
using PC28168.U20241G031.OpenPay.Platform.Settlements.Domain.Model.ValueObjects;
using PC28168.U20241G031.OpenPay.Platform.Shared.Domain.Repositories;

namespace PC28168.U20241G031.Openpay.Platform.Settlements.Domain.Repositories;

/// <summary>
/// Repository contract for managing <see cref="DisbursementOrder"/> aggregate roots.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public interface IDisbursementOrderRepository : IBaseRepository<DisbursementOrder>
{
    /// <summary>
    /// Checks whether a <see cref="DisbursementOrder"/> with the specified <see cref="OpenpayReference"/> already exists.
    /// </summary>
    /// <param name="orderTrackingCode">The order tracking code to verify.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns><c>true</c> if a record with the same tracking code exists; otherwise, <c>false</c>.</returns>
    /// <remarks>Piero Francisco Montes Chang</remarks>
    Task<bool> ExistsByOrderTrackingCodeAsync(OpenpayReference orderTrackingCode, CancellationToken cancellationToken = default);
}