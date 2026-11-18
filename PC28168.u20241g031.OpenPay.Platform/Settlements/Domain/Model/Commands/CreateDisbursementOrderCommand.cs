namespace PC28168.U20241G031.OpenPay.Platform.Settlements.Domain.Model.Commands;

/// <summary>
/// Command containing the primitive attributes required to create a new DisbursementOrder.
/// </summary>
/// <param name="OrderTrackingCode">The GUID string representing the order tracking code.</param>
/// <param name="AffiliateStoreId">The UUID string representing the affiliate store identifier.</param>
/// <param name="ScheduledFrom">The start date of the execution schedule.</param>
/// <param name="ScheduledTo">The end date of the execution schedule.</param>
/// <param name="TransferCapAmount">The decimal amount of the transfer cap.</param>
/// <param name="TransferCapCurrencyCode">The currency code of the transfer cap.</param>
/// <param name="User">The mandatory operator user identifier (max 20 characters).</param>
/// <param name="Status">The optional disbursement status (defaults to Queued = 10 if not specified).</param>
/// <param name="Remarks">The optional remarks text (max 85 characters).</param>
/// <remarks>Piero Francisco Montes Chang</remarks>
public record CreateDisbursementOrderCommand(
    string OrderTrackingCode,
    string AffiliateStoreId,
    DateOnly ScheduledFrom,
    DateOnly ScheduledTo,
    decimal TransferCapAmount,
    string TransferCapCurrencyCode,
    string User,
    string? Status = null,
    string? Remarks = null
);