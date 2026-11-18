namespace PC28168.U20241G031.OpenPay.Platform.Shared.Domain.Model;

/// <summary>
/// Contract for auditable aggregate roots that record creation and last update timestamps.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public interface IAuditableEntity
{
    DateTimeOffset? CreatedAt { get; set; }
    DateTimeOffset? UpdatedAt { get; set; }
}