namespace PC28168.U20241G031.OpenPay.Platform.Settlements.Domain.Model.ValueObjects;

/// <summary>
/// Enumeration representing the possible states of a DisbursementOrder starting at numeric value 10.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public enum DisbursementStatus
{
    /// <summary>
    /// Default status when a DisbursementOrder is registered without specifying a status (10).
    /// </summary>
    Queued = 10,

    /// <summary>
    /// Processed disbursement order status (11).
    /// </summary>
    Processed = 11,

    /// <summary>
    /// Cancelled disbursement order status (12).
    /// </summary>
    Cancelled = 12,

    /// <summary>
    /// Failed disbursement order status (13).
    /// </summary>
    Failed = 13
}