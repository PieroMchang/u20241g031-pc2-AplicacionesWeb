namespace PC28168.U20241G031.OpenPay.Platform.Settlements.Application.Errors;

/// <summary>
/// Application-level errors when creating a DisbursementOrder.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public enum CreateDisbursementOrderError
{
    DuplicateOrderTrackingCode,
    UnexpectedError
}