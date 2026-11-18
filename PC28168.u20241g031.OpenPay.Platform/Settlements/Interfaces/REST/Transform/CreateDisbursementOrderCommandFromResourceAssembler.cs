using PC28168.U20241G031.OpenPay.Platform.Settlements.Domain.Model.Commands;
using PC28168.U20241G031.OpenPay.Platform.Settlements.Interfaces.REST.Resources;

namespace PC28168.U20241G031.OpenPay.Platform.Settlements.Interfaces.REST.Transform;

/// <summary>
/// Assembler that converts a <see cref="CreateDisbursementOrderResource"/> into a <see cref="CreateDisbursementOrderCommand"/>.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public static class CreateDisbursementOrderCommandFromResourceAssembler
{
    public static CreateDisbursementOrderCommand ToCommandFromResource(CreateDisbursementOrderResource resource)
    {
        return new CreateDisbursementOrderCommand(
            resource.OrderTrackingCode,
            resource.AffiliateStoreId,
            resource.ScheduledFrom,
            resource.ScheduledTo,
            resource.TransferCapAmount,
            resource.TransferCapCurrencyCode,
            resource.User,
            resource.Status,
            resource.Remarks
        );
    }
}