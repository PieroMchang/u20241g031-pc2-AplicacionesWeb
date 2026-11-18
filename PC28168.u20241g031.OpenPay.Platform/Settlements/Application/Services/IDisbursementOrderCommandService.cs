using PC28168.U20241G031.OpenPay.Platform.Settlements.Application.Errors;
using PC28168.U20241G031.Openpay.Platform.Settlements.Domain.Model.Aggregates;
using PC28168.U20241G031.OpenPay.Platform.Settlements.Domain.Model.Commands;
using PC28168.U20241G031.OpenPay.Platform.Shared.Application.Patterns;

namespace PC28168.U20241G031.Openpay.Platform.Settlements.Application.Services;

/// <summary>
/// Command service interface for handling <see cref="DisbursementOrder"/> creation commands.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public interface IDisbursementOrderCommandService
{
    Task<Result<DisbursementOrder, CreateDisbursementOrderError>> Handle(
        CreateDisbursementOrderCommand command,
        CancellationToken cancellationToken = default);
}