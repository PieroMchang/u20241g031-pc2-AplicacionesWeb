namespace PC28168.U20241G031.OpenPay.Platform.Settlements.Interfaces.REST.Resources;

/// <summary>
/// Request DTO resource for creating a new DisbursementOrder.
/// </summary>
/// <param name="OrderTrackingCode">The GUID string identifying the disbursement order.</param>
/// <param name="AffiliateStoreId">The UUID string identifying the affiliate store.</param>
/// <param name="ScheduledFrom">The start date of the execution schedule (yyyy-MM-dd).</param>
/// <param name="ScheduledTo">The end date of the execution schedule (yyyy-MM-dd).</param>
/// <param name="TransferCapAmount">The decimal amount of the transfer cap.</param>
/// <param name="TransferCapCurrencyCode">The currency code of the transfer cap.</param>
/// <param name="User">The operator user identifier (mandatory, max 20 characters).</param>
/// <param name="Status">The optional status name or numeric string (defaults to Queued = 10).</param>
/// <param name="Remarks">The optional remarks text (max 85 characters).</param>
/// <remarks>Piero Francisco Montes Chang</remarks>
public record CreateDisbursementOrderResource(
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