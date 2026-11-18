namespace PC28168.U20241G031.OpenPay.Platform.Settlements.Domain.Model.ValueObjects;

/// <summary>
/// Value object representing the unique GUID tracking code of a disbursement order generated in another bounded context.
/// </summary>
/// <remarks>Piero Francisco Montes Chang</remarks>
public record OpenpayReference
{
    /// <summary>
    /// Gets the GUID value of the Openpay reference.
    /// </summary>
    public Guid Value { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenpayReference"/> record with a GUID value.
    /// </summary>
    /// <param name="value">The GUID value.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is <see cref="Guid.Empty"/>.</exception>
    /// <remarks>Piero Francisco Montes Chang</remarks>
    public OpenpayReference(Guid value)
    {
        // Business Rule 2: OpenpayReference contains a Guid Value uniquely identifying the disbursement order.
        if (value == Guid.Empty)
        {
            throw new ArgumentException("OpenpayReference Value cannot be an empty Guid.", nameof(value));
        }

        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenpayReference"/> record by parsing a GUID string.
    /// </summary>
    /// <param name="value">The string representation of the GUID.</param>
    /// <exception cref="ArgumentException">Thrown when <paramref name="value"/> is not a valid non-empty GUID.</exception>
    /// <remarks>Piero Francisco Montes Chang</remarks>
    public OpenpayReference(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !Guid.TryParse(value, out var parsedGuid) || parsedGuid == Guid.Empty)
        {
            throw new ArgumentException("OpenpayReference must be a valid non-empty Guid string.", nameof(value));
        }

        Value = parsedGuid;
    }
}