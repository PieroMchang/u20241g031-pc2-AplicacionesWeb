using System.ComponentModel.DataAnnotations.Schema;
using PC28168.U20241G031.OpenPay.Platform.Shared.Domain.Model;

namespace PC28168.U20241G031.Openpay.Platform.Settlements.Domain.Model.Aggregates;

/// <summary>
/// Partial class extending <see cref="DisbursementOrder"/> with audit timestamps (Rule 15).
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public partial class DisbursementOrder : IAuditableEntity
{
    [Column("CreatedAt")]
    public DateTimeOffset? CreatedAt { get; set; }

    [Column("UpdatedAt")]
    public DateTimeOffset? UpdatedAt { get; set; }
}