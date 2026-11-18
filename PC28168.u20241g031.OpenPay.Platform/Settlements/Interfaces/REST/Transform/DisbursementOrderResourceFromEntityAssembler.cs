using PC28168.U20241G031.Openpay.Platform.Settlements.Domain.Model.Aggregates;
using PC28168.U20241G031.OpenPay.Platform.Settlements.Interfaces.REST.Resources;

namespace PC28168.U20241G031.OpenPay.Platform.Settlements.Interfaces.REST.Transform;

/// <summary>
/// Assembler that converts a <see cref="DisbursementOrder"/> entity into a <see cref="DisbursementOrderResource"/> response DTO.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public static class DisbursementOrderResourceFromEntityAssembler
{
    public static DisbursementOrderResource ToResourceFromEntity(DisbursementOrder entity)
    {
        return new DisbursementOrderResource(
            entity.Id,
            entity.OrderTrackingCode.Value.ToString(),
            entity.AffiliateStoreId.Value.ToString(),
            entity.ExecutionSchedule.ScheduledFrom.ToString("yyyy-MM-dd"),
            entity.ExecutionSchedule.ScheduledTo.ToString("yyyy-MM-dd"),
            entity.TransferCap.Amount,
            entity.TransferCap.CurrencyCode,
            entity.Status.ToString(),
            entity.User,
            entity.Remarks,
            entity.UpdatedAt
        );
    }
}